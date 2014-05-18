using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    public interface IMessengerForm: IView
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