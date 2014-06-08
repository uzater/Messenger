using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MessengerClientLib;

namespace MessengerClientGUI
{
    sealed partial class MessengerForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(611, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(92, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "{userName}";
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
            this.listBoxUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(615, 72);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(158, 420);
            this.listBoxUsers.TabIndex = 3;
            this.listBoxUsers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxUsers_DrawItem);
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Enabled = false;
            this.textBoxMessage.Location = new System.Drawing.Point(5, 473);
            this.textBoxMessage.MaxLength = 900;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(485, 20);
            this.textBoxMessage.TabIndex = 4;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Enabled = false;
            this.buttonSendMessage.Location = new System.Drawing.Point(499, 471);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(106, 23);
            this.buttonSendMessage.TabIndex = 5;
            this.buttonSendMessage.Text = "Отправить";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.Location = new System.Drawing.Point(5, 9);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.ReadOnly = true;
            this.richTextBoxMessages.Size = new System.Drawing.Size(600, 455);
            this.richTextBoxMessages.TabIndex = 6;
            this.richTextBoxMessages.Text = "Выберите пользователя в списке справа\n";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Максимальная длина ообщения не более 900 символов";
            // 
            // MessengerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxMessages);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelName);
            this.Name = "MessengerForm";
            this.Text = "Messenger";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        public void SetMyName(string username)
        {
            labelName.Text = username;
        }

        public void StartChatWithUser(string username, string history)
        {
            Text = "Messenger | " + username;
            TextBoxMessage.Enabled = true;
            ButtonSendMessage.Enabled = true;

            RichTextBoxMessages.Text = history;
        }

        public void UpdateHistory(string history)
        {
            RichTextBoxMessages.Text = history;

            TextBoxMessage.Clear();

            RichTextBoxMessages.SelectionStart = RichTextBoxMessages.TextLength;
            RichTextBoxMessages.ScrollToCaret();
        }

        public void RefreshUserList(List<ShowedUser> showedUserList, int focusedIndex)
        {
            ListBoxUsers.BeginUpdate();
            
            ListBoxUsers.Items.Clear();

            foreach (ShowedUser user in showedUserList)
                listBoxUsers.Items.Add(((user.Onlinek__BackingField) ? "*" : "") + user.Usernamek__BackingField +
                                            ((user.NewMessagesCount != 0) ? (" (" + user.NewMessagesCount + ")") : ""));


            ListBoxUsers.SelectedIndex = focusedIndex;

            ListBoxUsers.EndUpdate();
        }

        private DataGridView dataGridView1;
        private Label label1;
    }
}