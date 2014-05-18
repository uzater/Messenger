using System;
using System.Windows.Forms;
using MessengerClientLib;
using MessengerClientLib.Interfaces;

namespace MessengerClientGUI
{
    public sealed partial class MessengerForm : Form, IMessengerForm
    {
        private readonly ApplicationContext _context;
        public MessengerForm(ApplicationContext context)
        {
            DoubleBuffered = true;
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

// ReSharper disable once ConvertToAutoProperty
        public Label LabelName
        {
            get { return labelName; }
            set { labelName = value; }
        }

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

// ReSharper disable once ConvertToAutoProperty
        public Button ButtonSendMessage
        {
            get { return buttonSendMessage; }
            set { buttonSendMessage = value; }
        }

// ReSharper disable once ConvertToAutoProperty
        public RichTextBox RichTextBoxMessages
        {
            get { return richTextBoxMessages; }
            set { richTextBoxMessages = value; }
        }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChangedAct != null)
                SelectedIndexChangedAct(this, new SelectedIndexChangedArgs(listBoxUsers.SelectedIndex));
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