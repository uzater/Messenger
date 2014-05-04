using System;
using System.Windows.Forms;
using MessengerClientLib;

namespace MessengerClientGUI
{
    public partial class MessengerForm : Form, IMessengerForm
    {
        private readonly ApplicationContext _context;
        public MessengerForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        public event EventHandler<SelectedIndexChangedArgs> SelectedIndexChangedAct;
        public event EventHandler<SendMessageArgs> SendMessageAct;

        public Label LabelName { get; set; }

        public ListBox ListBoxUsers
        {
            get { return listBoxUsers; }
            set { listBoxUsers = value; }
        }

        public TextBox TextBoxMessage
        {
            get { return textBoxMessage; }
            set { textBoxMessage = value; }
        }

        public Button ButtonSendMessage { get; set; }

        public RichTextBox RichTextBoxMessages { get; set; }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChangedAct != null)
                SelectedIndexChangedAct(this, new SelectedIndexChangedArgs(listBoxUsers.SelectedItem.ToString()));
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (SendMessageAct != null)
                SendMessageAct(this, new SendMessageArgs(textBoxMessage.Text));
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SendMessageAct != null)
            {
                SendMessageAct(this, new SendMessageArgs(textBoxMessage.Text));
            }
        }
    }
}