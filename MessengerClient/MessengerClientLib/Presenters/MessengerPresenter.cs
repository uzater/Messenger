using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;
using Message = MessengerClientLib.MessengerServiceReference.Message;
using Timer = System.Timers.Timer;

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

        public List<User> UserList;
        private User LoggedUser { get; set; }
        private User FocusedUser { get; set; }
        private List<Message> Messages { get; set; }
        private List<History> Histories { get; set; }
        public Timer Timer { get; set; }

        private void InitializeMessengerForm()
        {
            View.LabelName.Text = LoggedUser.Usernamek__BackingField;
            FocusedUser = null;
            UserList = new List<User>();

            Histories = new List<History>();

            Messages = new List<Message>();

            if (UserList != null)
                foreach (User user in UserList)
                    Histories.Add(new History(user));

            Timer = new Timer { Interval = 1000 };
            Timer.Elapsed += RefreshUserList;
            Timer.Elapsed += GetNewMessages;
            Timer.Enabled = true;
        }

        private void GetUsers()
        {
            using (var client = new MessengerServiceClient())
            {
                UserList = client.GetUsers(LoggedUser.Idk__BackingField).ToList();
            }
        }

        private void RefreshUserList(object sender, ElapsedEventArgs e)
        {
            View.ListBoxUsers.Invoke((MethodInvoker) (() => View.ListBoxUsers.BeginUpdate()));

            GetUsers();

            ClearUserList();

            foreach (User user in UserList)
            {
                int countofNewMessages = (Messages != null) ? (Messages.Where(m => m.SenderId == user.Idk__BackingField).ToList()).Count : 0;
                View.ListBoxUsers.Invoke(
                    (MethodInvoker) (() => View.ListBoxUsers.Items.Add(((user.Onlinek__BackingField) ? "*" : "") + user.Usernamek__BackingField + ((countofNewMessages != 0) ? (" (" + countofNewMessages + ")") : ""))));

            }

            if (FocusedUser != null)
                View.ListBoxUsers.Invoke(
                    (MethodInvoker)
                        (() =>
                            View.ListBoxUsers.SelectedIndex = UserList.FindIndex(u => u.Idk__BackingField == FocusedUser.Idk__BackingField)));

            View.ListBoxUsers.Invoke((MethodInvoker)(() => View.ListBoxUsers.EndUpdate()));
        }


        private void ClearUserList()
        {
            View.ListBoxUsers.Invoke((MethodInvoker) (() => View.ListBoxUsers.Items.Clear()));
        }


        private void GetNewMessages(object sender, ElapsedEventArgs e)
        {
            using (var client = new MessengerServiceClient())
            {
                foreach (User user in UserList)
                    Messages.AddRange(client.GetMessages(user.Idk__BackingField, LoggedUser.Idk__BackingField).ToList());
            }
        }

        private void DoSelectedIndexChangedAct(object sender, SelectedIndexChangedArgs e)
        {
            FocusedUser = UserList[e.Position];

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
                Time = (int)System.Diagnostics.Stopwatch.GetTimestamp(),
                Text = e.Message
            };

            var currentHistory = Histories.First(h => h.User.Idk__BackingField == FocusedUser.Idk__BackingField);
            currentHistory.Add(message);
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