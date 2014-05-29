using System.Collections.Generic;

namespace MessengerServiceLib
{
    /// <summary>
    /// Интерфейс хранилища данных приложения.
    /// </summary>
    public interface IDataStore
    {
        /// <summary>
        /// Вход пользователя в чат
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>Объект типа 'User' - текущий пользователь</returns>
        User Login(string username);

        /// <summary>
        /// Получение всех пользователей чата
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <returns>Список всех пользователей, за исключением текущего</returns>
        IEnumerable<User> GetUsers(int userId);

        /// <summary>
        /// Получение имени пользователя по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Имя пользователя</returns>
        string GetUserName(int userId);

        /// <summary>
        /// Получение новых сообщений от одного пользователя другому
        /// </summary>
        /// <param name="sender">Пользователь-отправитель</param>
        /// <param name="reciever">Пользователь-получатель</param>
        /// <returns>Список сообщений</returns>
        IEnumerable<Message> GetMessages(int sender, int reciever);

        /// <summary>
        /// Проверка существования пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>TRUE, если пользователь существует, иначе FALSE</returns>
        bool IfUser(int id);

        /// <summary>
        /// Добавление нового сообщения
        /// </summary>
        /// <param name="message">Сообщение для добавления</param>
        void AddMessage(Message message);
    }
}