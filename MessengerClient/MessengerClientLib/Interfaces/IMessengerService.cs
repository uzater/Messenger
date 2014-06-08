using System;
using System.Collections.Generic;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса мессенджера
    /// </summary>
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

        /// <summary>
        ///     Получение пользователей
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        void GetUsers(int userId);

        /// <summary>
        ///     Получение новых сообщений
        /// </summary>
        void GetNewMessages(object sender, EventArgs eventArgs);

        /// <summary>
        ///     Отправка сообщения
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        void SendMessage(Message message);

        /// <summary>
        ///     Инициализация мессенджера
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Выделение пользователя
        /// </summary>
        /// <param name="index">Индекс</param>
        void DoSelectedIndexChangeAct(int index);

        /// <summary>
        ///     Получение следующего сообщения
        /// </summary>
        /// <returns>Новое сообщение</returns>
        Message GetNextNewMessage();

        /// <summary>
        ///     Установка пользователя для которого запущен чат
        /// </summary>
        /// <param name="loggedUser">Пользователь для которого запущен чат</param>
        void SetLoggedUser(User loggedUser);
    }
}