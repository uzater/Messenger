using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MessengerClientLib.EventsArgs;
using MessengerClientLib.Interfaces;

namespace MessengerClientGUI
{
    public partial class LoginForm : Form, ILoginForm
    {
        public event EventHandler<LoginArgs> LoginAct;
        private readonly ApplicationContext _context;
        public LoginForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        private void textBoxLoginName_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = textBoxLoginName.Text != string.Empty;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxLoginName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Имя пользователя не может быть пустым, содержать только пробелы.");
                textBoxLoginName.Text = "";
                return;
            }

            if (LoginAct != null && textBoxLoginName.Text.Trim() != string.Empty)
                LoginAct(sender, new LoginArgs(textBoxLoginName.Text.Trim()));
        }
        private void textBoxLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonLogin_Click(sender, e);
        }
    }
}