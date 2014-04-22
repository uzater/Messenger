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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (var client = new MessengerServiceClient())
            {
                _loggedUserId = client.Login(textBoxLoginName.Text);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void textBoxLoginName_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = Text.Length != 0;
        }

        private void textBoxLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonLogin_Click(sender, e);
        }
    }
}
