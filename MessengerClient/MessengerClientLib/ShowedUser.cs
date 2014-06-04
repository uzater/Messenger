using System;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib
{
    /// <summary>
    /// Пользователь для показа в GUI
    /// </summary>
    [Serializable]
    public class ShowedUser : User
    {
        /// <summary>
        /// Коллиество новых сообщений
        /// </summary>
        public int NewMessagesCount { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="online"></param>
        /// <param name="newMessagesCount">Колличество новых сообщений</param>
        public ShowedUser(int id, string name, bool online, int newMessagesCount)
        {
            Idk__BackingField = id;
            Usernamek__BackingField = name;
            Onlinek__BackingField = online;
            NewMessagesCount = newMessagesCount;
        }
        /// <summary>
        /// Статический метод конвертирования пользователя для отображения в GUI 
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Пользователь для отображения в GUI</returns>
        public static ShowedUser From(User user)
        {
            return new ShowedUser(user.Idk__BackingField, user.Usernamek__BackingField, user.Onlinek__BackingField, 0);
        }
        /// <summary>
        /// Преобразует пользователя в строку
        /// </summary>
        /// <returns>Строковое представление пользователя</returns>
        public override string ToString()
        {
            return "ShowedUser( id: " + Idk__BackingField + " username: " + Usernamek__BackingField +
                   ((Onlinek__BackingField)
                ? " online"
                : "") + " new messages: " + NewMessagesCount + " )";
        }
    }
}