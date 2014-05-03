using System;
using System.Windows.Forms;
using MessengerClientLib;

namespace MessengerClientGUI
{
    public partial class LoginForm : Form, ILoginForm
    {
        public event EventHandler<LoginArgs> LoginAct;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBoxLoginName_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = textBoxLoginName.Text != string.Empty;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(LoginAct != null)
                LoginAct(sender, new LoginArgs(textBoxLoginName.Text));
        }
    }
}