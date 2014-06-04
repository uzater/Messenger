using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MessengerClientLib.EventsArgs;

namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Форма мессенджера
    /// </summary>
    public interface IMessengerForm: IView
    {
        /// <summary>
        /// Лейбел для собственного имени
        /// </summary>
        Label LabelName { get; set; }
        /// <summary>
        /// Список пользователей
        /// </summary>
        ListBox ListBoxUsers { get; set; }
        /// <summary>
        /// Поле ввода сообщения
        /// </summary>
        TextBox TextBoxMessage { get; set; }
        /// <summary>
        /// Кнопка отправки сообщения
        /// </summary>
        Button ButtonSendMessage { get; set; }
        /// <summary>
        /// Область для отображения сообщений
        /// </summary>
        RichTextBox RichTextBoxMessages { get; set; }
        /// <summary>
        /// Событие выбора пользователя
        /// </summary>
        event EventHandler<SelectedIndexChangedArgs> SelectedIndexChangedAct;
        /// <summary>
        /// Событие отправки сообщения
        /// </summary>
        event EventHandler<SendMessageArgs> SendMessageAct;
        /// <summary>
        /// Установка собствнного имени пользователя
        /// </summary>
        /// <param name="username">Имя</param>
        void SetMyName(string username);
        /// <summary>
        /// Начало чата
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="history">История</param>
        void StartChatWithUser(string username, string history);
        /// <summary>
        /// Обновление истории
        /// </summary>
        /// <param name="history">История</param>
        void UpdateHistory(string history);

        /// <summary>
        /// ОБновление списка пользователей
        /// </summary>
        /// <param name="showedUserList">Список пользователей</param>
        /// <param name="focusedIndex">Индекс выбранного пользователя</param>
        void RefreshUserList(List<ShowedUser> showedUserList, int focusedIndex);
    }
}