using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using MessengerClientGUI.ServiceReference1;
using Message = MessengerClientGUI.ServiceReference1.Message;

namespace MessengerClientGUI
{
    public partial class MessengerForm : Form
    {
        private int _logedUserID;
        private IEnumerable<User> _userList;
        private System.Timers.Timer Timer;
        private int _focusedUserId;
        private List<History> Histories;

        public MessengerForm()
        {
            InitializeComponent();
        }

        private void MessengerForm_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
                Close();
            using (var client = new MessengerServiceClient())
            {
                labelName.Text = client.GetUserName(loginForm._logedUserId);
                _logedUserID = loginForm._logedUserId;
            }

            _focusedUserId = -1;
            RefreshUsers(this, null);
            Histories = new List<History>();
            foreach (var user in _userList)
            {
                Histories.Add(new History(user.Idk__BackingField, "Chat with " + user.Usernamek__BackingField + "\n"));
            }

            Timer = new System.Timers.Timer { Interval = 1000 };
            Timer.Elapsed += RefreshUsers;
            Timer.Elapsed += GetNewMessages;
            Timer.Enabled = true;
        }

        private void GetNewMessages(object sender, ElapsedEventArgs e)
        {
            using (var client = new MessengerServiceClient())
            {
                foreach (var user in _userList)
                {
                    var messages = client.GetMessages(_logedUserID, user.Idk__BackingField);
                    foreach (var message in messages)
                    {
                        Histories.First(h => h.UserID == user.Idk__BackingField).Text += user.Usernamek__BackingField + ": " + message.Text + "\n";
                    }
                }
            }
        }

        private void RefreshUsers(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            using (var client = new MessengerServiceClient())
            {
                _userList = client.GetUsers(_logedUserID);

                ClearUserList();
                
                foreach (var user in _userList)
                {
                    listBoxUsers.Invoke((MethodInvoker)(() => listBoxUsers.Items.Add(user.Usernamek__BackingField)));//quas-exort-овый invoker
                    //TODO: online users BOLD

                }

                if (_focusedUserId != -1)
                    listBoxUsers.Invoke((MethodInvoker)(() => listBoxUsers.SelectedIndex = listBoxUsers.FindStringExact(_userList.First(u => u.Idk__BackingField == _focusedUserId).Usernamek__BackingField)));
            }
        }

        private void ClearUserList()
        {
            if (listBoxUsers.InvokeRequired)
            {
                listBoxUsers.Invoke(new MethodInvoker(ClearUserList));
                return;
            }

            listBoxUsers.Items.Clear();
            
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBoxUsers.SelectedItem.ToString();

            _focusedUserId = _userList.First(u => u.Usernamek__BackingField == curItem).Idk__BackingField;

            this.richTextBoxMessages.Text = Histories.First(h => h.UserID == _focusedUserId).Text;
            this.Text = "Messenger | " + curItem;
            textBoxMessage.Enabled = true;
            buttonSendMessage.Enabled = true;
        }

        private void MessengerForm_Closing(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (textBoxMessage.Text == "") return;
            Histories.First(h => h.UserID == _focusedUserId).Text += labelName.Text + ": " + textBoxMessage.Text + "\n";
            richTextBoxMessages.Text = Histories.First(h => h.UserID == _focusedUserId).Text;
                
            var message = new Message(_logedUserID, _userList.First(u => u.Usernamek__BackingField == listBoxUsers.SelectedItem.ToString()).Idk__BackingField, (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, textBoxMessage.Text);
                
            using (var client = new MessengerServiceClient())
            {
                client.SendMessage(message);
            }

            textBoxMessage.Clear();

            richTextBoxMessages.SelectionStart = richTextBoxMessages.TextLength;
            richTextBoxMessages.ScrollToCaret();
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonSendMessage_Click(sender, e);
            }
        }
    }
}
