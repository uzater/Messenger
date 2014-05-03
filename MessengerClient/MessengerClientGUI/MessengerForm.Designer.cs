using System.ComponentModel;
using System.Windows.Forms;

namespace MessengerClientGUI
{
    partial class MessengerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelName = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.ButtonSendMessage = new System.Windows.Forms.Button();
            this.RichTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelName.Location = new System.Drawing.Point(611, 7);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(92, 20);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "{userName}";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogout.Location = new System.Drawing.Point(611, 30);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(88, 29);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(615, 72);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(158, 420);
            this.listBoxUsers.TabIndex = 3;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Enabled = false;
            this.textBoxMessage.Location = new System.Drawing.Point(5, 473);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(485, 20);
            this.textBoxMessage.TabIndex = 4;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
            // 
            // buttonSendMessage
            // 
            this.ButtonSendMessage.Enabled = false;
            this.ButtonSendMessage.Location = new System.Drawing.Point(499, 471);
            this.ButtonSendMessage.Name = "ButtonSendMessage";
            this.ButtonSendMessage.Size = new System.Drawing.Size(106, 23);
            this.ButtonSendMessage.TabIndex = 5;
            this.ButtonSendMessage.Text = "Отправить";
            this.ButtonSendMessage.UseVisualStyleBackColor = true;
            this.ButtonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // richTextBoxMessages
            // 
            this.RichTextBoxMessages.Location = new System.Drawing.Point(5, 9);
            this.RichTextBoxMessages.Name = "RichTextBoxMessages";
            this.RichTextBoxMessages.ReadOnly = true;
            this.RichTextBoxMessages.Size = new System.Drawing.Size(600, 455);
            this.RichTextBoxMessages.TabIndex = 6;
            this.RichTextBoxMessages.Text = "Выберите пользователя в списке справа\n";
            // 
            // MessengerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 504);
            this.Controls.Add(this.RichTextBoxMessages);
            this.Controls.Add(this.ButtonSendMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.LabelName);
            this.Name = "MessengerForm";
            this.Text = "Messenger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.TextBox textBoxMessage;
    }
}