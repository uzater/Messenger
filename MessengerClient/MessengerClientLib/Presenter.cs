using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using MessengerClientLib.MessengerServiceReference;
using Message = MessengerClientLib.MessengerServiceReference.Message;
using Timer = System.Timers.Timer;

namespace MessengerClientLib
{
    public class Presenter
    {
        public Presenter(ILoginForm loginForm, IMessengerForm messengerForm)
        {
            LoginForm = loginForm;
            MessengerForm = messengerForm;

            LoginForm.LoginAct += DoLoginAct;
            MessengerForm.SelectedIndexChangedAct += DoSelectedIndexChangedAct;
            MessengerForm.SendMessageAct += DoSendMessage;
        }

        private ILoginForm LoginForm { get; set; }
        private IMessengerForm MessengerForm { get; set; }

        private User LoggedUser { get; set; }
        private User FocusedUser { get; set; }
        private List<User> UserList { get; set; }
        private List<History> Histories { get; set; }
        public Timer Timer { get; set; }


        public void DoLoginAct(object sender, LoginArgs e)
        {
            using (var client = new MessengerServiceClient())
            {
                LoggedUser = client.Login(e.Username);

                if (LoggedUser != null)
                {
                    InitializeMessengerForm();
                    ((Form)LoginForm).Close();
                }
            }
        }

        private void InitializeMessengerForm()
        {
            MessengerForm.LabelName.Text = LoggedUser.Usernamek__BackingField;
            FocusedUser = null;
            UserList = null;

            RefreshUserList(this, null);

            Histories = new List<History>();
            if (UserList != null)
                foreach (User user in UserList)
                    Histories.Add(new History(user.Idk__BackingField, "Chat with " + user.Usernamek__BackingField + "\n"));

            Timer = new Timer {Interval = 1000};
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
            GetUsers();

            ClearUserList();

            foreach (User user in UserList)
            {
                //MessengerForm.ListBoxUsers.Invoke(
                //    (MethodInvoker) (() => MessengerForm.ListBoxUsers.Items.Add(user.Usernamek__BackingField)));
                MessengerForm.ListBoxUsers.Items.Add(user.Usernamek__BackingField);
            }

            if (FocusedUser != null)
                //MessengerForm.ListBoxUsers.Invoke(
                //    (MethodInvoker)
                //        (() =>
                //            MessengerForm.ListBoxUsers.SelectedIndex =
                //                MessengerForm.ListBoxUsers.FindStringExact(
                //                    UserList.First(u => u.Idk__BackingField == FocusedUser.Idk__BackingField).Usernamek__BackingField)));
                MessengerForm.ListBoxUsers.SelectedIndex =
                    MessengerForm.ListBoxUsers.FindStringExact(
                        UserList.First(u => u.Idk__BackingField == FocusedUser.Idk__BackingField)
                            .Usernamek__BackingField);
        }


        private void ClearUserList()
        {
            //MessengerForm.ListBoxUsers.Invoke((MethodInvoker) (() => MessengerForm.ListBoxUsers.Items.Clear()));
            MessengerForm.ListBoxUsers.Items.Clear();
        }


        private void GetNewMessages(object sender, ElapsedEventArgs e)
        {
            using (var client = new MessengerServiceClient())
            {
                foreach (User user in UserList)
                {
                    Message[] messages = client.GetMessages(LoggedUser.Idk__BackingField, user.Idk__BackingField);

                    foreach (Message message in messages)
                        Histories.First(h => h.UserId == user.Idk__BackingField).Text += user.Usernamek__BackingField + ": " + message.Text + "\n";
                }
            }
        }

        private void DoSelectedIndexChangedAct(object sender, SelectedIndexChangedArgs e)
        {
            string curItem = e.Username;

            FocusedUser = UserList.First(u => u.Usernamek__BackingField == curItem);

            if (Histories.All(h => h.UserId != FocusedUser.Idk__BackingField))
                Histories.Add(new History(FocusedUser.Idk__BackingField, "Chat with " + curItem + "\n"));

            MessengerForm.RichTextBoxMessages.Text = Histories.First(h => h.UserId == FocusedUser.Idk__BackingField).Text;

            ((Form) MessengerForm).Text = "Messenger | " + curItem;
            MessengerForm.TextBoxMessage.Enabled = true;
            MessengerForm.ButtonSendMessage.Enabled = true;
        }


        private void DoSendMessage(object sender, SendMessageArgs e)
        {
            if (e.Message == "") return;
            Histories.First(h => h.UserId == FocusedUser.Idk__BackingField).Text += LoggedUser.Usernamek__BackingField + ": " + e.Message + "\n";
            MessengerForm.RichTextBoxMessages.Text = Histories.First(h => h.UserId == FocusedUser.Idk__BackingField).Text;

            var message = new Message
            {
                UserID = LoggedUser.Idk__BackingField,
                DestinationID = FocusedUser.Idk__BackingField,
                Time = (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                Text = e.Message
            };

            using (var client = new MessengerServiceClient())
            {
                client.SendMessage(message);
            }

            MessengerForm.TextBoxMessage.Clear();

            MessengerForm.RichTextBoxMessages.SelectionStart = MessengerForm.RichTextBoxMessages.TextLength;
            MessengerForm.RichTextBoxMessages.ScrollToCaret();
        }
    }
}