using System;
using System.Windows.Forms;

namespace MessengerClientLib
{
    public interface IMessengerForm
    {
        Label LabelName { get; set; }
        ListBox ListBoxUsers { get; set; }
        TextBox TextBoxMessage { get; set; }
        Button ButtonSendMessage { get; set; }
        RichTextBox RichTextBoxMessages { get; set; }
        event EventHandler<SelectedIndexChangedArgs> SelectedIndexChangedAct;
        event EventHandler<SendMessageArgs> SendMessageAct;
    }
}