using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;
using Message = MessengerClientLib.MessengerServiceReference.Message;
using Timer = System.Windows.Forms.Timer;

namespace MessengerClientLib.Presenters
{
    public class MessengerPresenter: BasePresener<IMessengerForm, User>
    {

        public MessengerPresenter(IApplicationController controller, IMessengerForm view)
            : base(controller, view)
        {
            View.SelectedIndexChangedAct += DoSelectedIndexChangedAct;
            View.SendMessageAct += DoSendMessage;
        }

        public List<ShowedUser> ShowedUserList;
        private static User LoggedUser { get; set; }
        private User FocusedUser { get; set; }
        private List<Message> Messages { get; set; }
        private List<History> Histories { get; set; }
        public Timer Timer { get; set; }

        private void InitializeMessengerForm()
        {
            View.LabelName.Text = LoggedUser.Usernamek__BackingField;
            FocusedUser = null;
            ShowedUserList = new List<ShowedUser>();

            Histories = new List<History>();

            Messages = new List<Message>();

            if (ShowedUserList != null)
                foreach (ShowedUser user in ShowedUserList)
                    Histories.Add(new History(user));

            Timer = new Timer {Interval = 1000};
            Timer.Tick += RefreshUserList;
            Timer.Tick += GetNewMessages;
            Timer.Enabled = true;
        }

        private void GetUsers()
        {
            using (var client = new MessengerServiceClient())
            {
                ShowedUserList = client.GetUsers(LoggedUser.Idk__BackingField).ToList().Select(ShowedUser.From).ToList();
            }
        }

        private void RefreshUserList(object sender, EventArgs e)
        {
            //View.ListBoxUsers.Invoke((MethodInvoker) (() => View.ListBoxUsers.BeginUpdate()));
            View.ListBoxUsers.BeginUpdate();

            GetUsers();

            ClearUserList();

            foreach (ShowedUser user in ShowedUserList)
            {
                int countofNewMessages = (Messages != null)
                    ? (Messages.Where(m => m.SenderId == user.Idk__BackingField).ToList()).Count
                    : 0;
                //View.ListBoxUsers.Invoke(
                //    (MethodInvoker) (() => View.ListBoxUsers.Items.Add(((user.Onlinek__BackingField) ? "*" : "") + user.Usernamek__BackingField + ((countofNewMessages != 0) ? (" (" + countofNewMessages + ")") : ""))));

                //View.ListBoxUsers.Font = user.Onlinek__BackingField ? new Font(View.ListBoxUsers.Font, FontStyle.Bold) : new Font(View.ListBoxUsers.Font, FontStyle.Regular);

                View.ListBoxUsers.Items.Add(((user.Onlinek__BackingField) ? "*" : "") + user.Usernamek__BackingField +
                                            ((countofNewMessages != 0) ? (" (" + countofNewMessages + ")") : ""));
                //View.ListBoxUsers.Fo
            }
            //if (FocusedUser != null)
            //    View.ListBoxUsers.Invoke(
            //        (MethodInvoker)
            //            (() =>
            //                View.ListBoxUsers.SelectedIndex = ShowedUserList.FindIndex(u => u.Idk__BackingField == FocusedUser.Idk__BackingField)));
            if (FocusedUser != null)
                View.ListBoxUsers.SelectedIndex =
                    ShowedUserList.FindIndex(u => u.Idk__BackingField == FocusedUser.Idk__BackingField);

            //View.ListBoxUsers.Invoke((MethodInvoker)(() => View.ListBoxUsers.EndUpdate()));
            View.ListBoxUsers.EndUpdate();
        }


        private void ClearUserList()
        {
            //View.ListBoxUsers.Invoke((MethodInvoker) (() => View.ListBoxUsers.Items.Clear()));
            View.ListBoxUsers.Items.Clear();
        }


        private void GetNewMessages(object sender, EventArgs eventArgs)
        {
            using (var client = new MessengerServiceClient())
            {
                foreach (ShowedUser user in ShowedUserList)
                {
                    Messages.AddRange(client.GetMessages(user.Idk__BackingField, LoggedUser.Idk__BackingField).ToList());
                }
            }
        }

        private void DoSelectedIndexChangedAct(object sender, SelectedIndexChangedArgs e)
        {
            FocusedUser = ShowedUserList[e.Position];

            if (Histories.All(h => h.User.Idk__BackingField != FocusedUser.Idk__BackingField))
                Histories.Add(new History(FocusedUser));

            ((Form)View).Text = "Messenger | " + FocusedUser.Usernamek__BackingField;
            View.TextBoxMessage.Enabled = true;
            View.ButtonSendMessage.Enabled = true;

            while (Messages.Any(m => m.SenderId == FocusedUser.Idk__BackingField))
                Histories.First(h => h.User.Idk__BackingField == FocusedUser.Idk__BackingField).Add(GetNextNewMessage());

            View.RichTextBoxMessages.Text = Histories.First(h => h.User.Idk__BackingField == FocusedUser.Idk__BackingField).Text;
        }

        private Message GetNextNewMessage()
        {
            var message = Messages.First(m => m.SenderId == FocusedUser.Idk__BackingField);
            Messages.Remove(message);

            return message;
        }


        private void DoSendMessage(object sender, SendMessageArgs e)
        {
            if (e.Message == string.Empty) return;
            
            var message = new Message
            {
                SenderId = LoggedUser.Idk__BackingField,
                RecieverId = FocusedUser.Idk__BackingField,
                Time = DateTime.Now,
                Text = e.Message
            };

            var currentHistory = Histories.First(h => h.User.Idk__BackingField == FocusedUser.Idk__BackingField);
            currentHistory.Add(message, LoggedUser.Usernamek__BackingField);
            View.RichTextBoxMessages.Text = currentHistory.Text;

            using (var client = new MessengerServiceClient())
            {
                client.SendMessage(message);
            }

            View.TextBoxMessage.Clear();

            View.RichTextBoxMessages.SelectionStart = View.RichTextBoxMessages.TextLength;
            View.RichTextBoxMessages.ScrollToCaret();
        }

        public override void Run(User argument)
        {
            LoggedUser = argument;
            InitializeMessengerForm();
            View.Show();
        }
    }
}