﻿using System.Collections.Generic;
using System.ServiceModel;

namespace MessengerServiceLib
{
    /// <summary>
    /// Интерфейс сервиса для обмена сообщениями
    /// </summary>
    [ServiceContract]
    public interface IMessengerService
    {
        /// <summary>
        /// Вход пользователя в чат
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>Объект типа 'User' - текущий пользователь</returns>
        [OperationContract]
        User Login(string username);

        /// <summary>
        /// Получение всех пользователей чата
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <returns>Список всех пользователей, за исключением текущего</returns>
        [OperationContract]
        IEnumerable<User> GetUsers(int userId);

        /// <summary>
        /// Отправка нового сообщения
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        [OperationContract]
        void SendMessage(Message message);

        /// <summary>
        /// Получение имени пользователя по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Имя пользователя</returns>
        [OperationContract]
        string GetUserName(int userId);

        /// <summary>
        /// Получение новых сообщений от одного пользователя другому
        /// </summary>
        /// <param name="sender">Пользователь-отправитель</param>
        /// <param name="reciever">Пользователь-получатель</param>
        /// <returns>Список сообщений</returns>
        [OperationContract]
        IEnumerable<Message> GetMessages(int sender, int reciever);
    }
}