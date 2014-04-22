using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessengerClientGUI.ServiceReference1;

namespace MessengerClientGUI
{
    public partial class MessengerForm : Form
    {
        public MessengerForm()
        {
            InitializeComponent();
        }

        private void MessengerForm_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                Close();
             using (var client = new MessengerServiceClient())
            {
                 labelName.Text = client.GetUserName(loginForm._loggedUserId);
                 var users = client.GetUsers(loginForm._loggedUserId);
                foreach (var user in users)
                {
                    listBoxUsers.Items.Add(user.Usernamek__BackingField);
                }
                 
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBoxUsers.SelectedItem.ToString();

            this.richTextBoxMessages.Text = "Selected user: " + curItem + "\n";
            this.Text = "Messenger | " + curItem;
            textBoxMessage.Text = "";
            textBoxMessage.Enabled = true;
            buttonSendMessage.Enabled = true;
        }

        private void MessengerForm_Closing(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (textBoxMessage.Text != "")
            {
                richTextBoxMessages.Text += labelName.Text + ": " + textBoxMessage.Text + "\n";
                textBoxMessage.Clear();
                richTextBoxMessages.SelectionStart = richTextBoxMessages.TextLength;
                richTextBoxMessages.ScrollToCaret();
            }
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
