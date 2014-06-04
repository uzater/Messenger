using System;
using System.Collections.Generic;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    public interface IMessengerService
    {
        /// <summary>
        /// Список пользователей для показа
        /// </summary>
        List<ShowedUser> ShowedUserList { get; set; } 

        /// <summary>
        /// Текущий клиент
        /// </summary>
        User LoggedUser { get; set; }

        /// <summary>
        /// Пользователь с которым открыт чат
        /// </summary>
        User FocusedUser { get; set; }

        /// <summary>
        /// Список сообщений
        /// </summary>
        List<Message> Messages { get; set; }

        /// <summary>
        /// Список историй
        /// </summary>
        List<History> Histories { get; set; }

        void GetUsers(int userId);
        void GetNewMessages(object sender, EventArgs eventArgs);

        void SendMessage(Message message);

        void Initialize();

        void DoSelectedIndexChangeAct(int index);
        Message GetNextNewMessage();

        void SetLoggedUser(User loggedUser);
    }
}