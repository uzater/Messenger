using System;
using System.Drawing;
using System.Windows.Forms;
using MessengerClientLib.EventsArgs;
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
            if (textBoxMessage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Сообщение содержит запрещенные символы.");
                return;
            }


            if (SendMessageAct != null)
                SendMessageAct(this, new SendMessageArgs(textBoxMessage.Text));
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBoxMessage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Сообщение содержит запрещенные символы.");
                return;
            }

            if (e.KeyCode == Keys.Enter && SendMessageAct != null)
            {
                SendMessageAct(this, new SendMessageArgs(textBoxMessage.Text));
            }
        }

        private void listBoxUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle step = e.Bounds;

            e.DrawBackground();
            Brush myBrush = Brushes.Black;

            var myFont = new Font(Font.FontFamily, Font.Size, FontStyle.Regular, Font.Unit);

            if (listBoxUsers.Items[e.Index].ToString()[0] == '*')
            {
                myFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold, Font.Unit);
                e.Graphics.DrawString(listBoxUsers.Items[e.Index].ToString().Remove(0, 1), myFont, myBrush, step, StringFormat.GenericDefault);
            }
            else
            {
                e.Graphics.DrawString(listBoxUsers.Items[e.Index].ToString(), myFont, myBrush, step, StringFormat.GenericDefault);
            }
        }
    }
}