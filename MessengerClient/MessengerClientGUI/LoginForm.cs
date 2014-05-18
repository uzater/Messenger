using System;
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
            if(LoginAct != null)
                LoginAct(sender, new LoginArgs(textBoxLoginName.Text));
        }
    }
}