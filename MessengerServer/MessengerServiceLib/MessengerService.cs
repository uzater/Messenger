using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MessengerServiceLib
{
    /// <summary>
    /// Сервис для обмена сообщениями
    /// </summary>
    public class MessengerService : IMessengerService
    {
        /// <summary>
        /// Экземпляр интерфейса хранилища данных приложения. Текущее место хранения данных
        /// </summary>
        public IDataStore DataStore = new DataBase.DataBase();

        /// <summary>
        /// Вход пользователя в чат
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>Объект типа 'User' - текущий пользователь</returns>
        public User Login(string username)
        {
            try
            {
                return DataStore.Login(username);
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        /// <summary>
        /// Получение всех пользователей чата
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <returns>Список всех пользователей, за исключением текущего</returns>
        public IEnumerable<User> GetUsers(int userId)
        {
            try
            {
                var userList = DataStore.GetUsers(userId);
                return userList.Where(u => u.Id != userId);
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }     
        }

        /// <summary>
        /// Отправка нового сообщения
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        public void SendMessage(Message message)
        {
            try
            {
                if (DataStore.IfUser(message.SenderId) && DataStore.IfUser(message.RecieverId))
                    DataStore.AddMessage(message);
                else
                    throw new FaultException("Cann't send message. User not found.");
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
            
        }

        /// <summary>
        /// Получение имени пользователя по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Имя пользователя</returns>
        public string GetUserName(int userId)
        {
            try
            {
                return DataStore.GetUserName(userId);
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        /// <summary>
        /// Получение новых сообщений от одного пользователя другому
        /// </summary>
        /// <param name="sender">Пользователь-отправитель</param>
        /// <param name="reciever">Пользователь-получатель</param>
        /// <returns>Список сообщений</returns>
        public IEnumerable<Message> GetMessages(int sender, int reciever)
        {
            try
            {
                return DataStore.GetMessages(sender, reciever);
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }
    }
}