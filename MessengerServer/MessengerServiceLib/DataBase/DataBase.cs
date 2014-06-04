using System;
using System.Collections.Generic;
using System.Linq;

namespace MessengerServiceLib.DataBase
{
    /// <summary>
    /// Класс для формирования запросов к базе данных
    /// </summary>
    public class DataBase : IDataStore
    {
        /// <summary>
        /// Экземпляр интерфейса посредника работы с базой данных
        /// </summary>
        public IExecutor DBquery = new DataBaseQuery();

        /// <summary>
        /// Проверка существования пользователя
        /// </summary>
        /// <param name="query">Строка запроса (либо по идентификатору, либо по имени пользователя)</param>
        /// <returns>TRUE - если пользователь найден, FALSE - если пользователь не найден</returns>
        private bool CheckUser(string query)
        {
            var result = DBquery.Execute(query);
            return result.Readable;
        }

        /// <summary>
        /// Проверка существования пользователя по имени
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>TRUE, если пользователь существует, иначе FALSE</returns>
        public bool IfUser(string username)
        {
            return CheckUser("SELECT * FROM users WHERE name='" + username + "'");
        }

        /// <summary>
        /// Проверка существования пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>TRUE, если пользователь существует, иначе FALSE</returns>
        public bool IfUser(int id)
        {
            return CheckUser("SELECT * FROM users WHERE id='" + id + "'");
        }

        /// <summary>
        /// Вход пользователя в чат
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>Объект типа 'User' - текущий пользователь</returns>
        public User Login(string username)
        {
            var query = (IfUser(username))
                ? "UPDATE users SET refreshtime = NOW() WHERE name='" + username + "'"
                : "INSERT INTO users ('name') VALUES ('" + username + "')";
            DBquery.Execute(query);

            var result = DBquery.Execute("SELECT * FROM users WHERE name='" + username + "'");

            return !result.Readable ? null : new User((int)result.DataResult[0][0], (string)result.DataResult[0][1], true);
        }

        /// <summary>
        /// Получение всех пользователей чата
        /// </summary>
        /// <param name="userId">Идентификатор текущего пользователя</param>
        /// <returns>Список всех пользователей, за исключением текущего</returns>
        public IEnumerable<User> GetUsers(int userId)
        {
            if (!IfUser(userId))
                return null;

            DBquery.Execute("UPDATE users SET refreshtime = NOW() WHERE id='" + userId + "'");

            var result = DBquery.Execute("SELECT * FROM users");

            return result.DataResult.Select(user => new User((int) user[0], (string) user[1], (Int32) (DateTime.UtcNow.AddHours(4).Subtract((DateTime) user[2]).TotalSeconds) < 10)).ToList();
        }
        
        /// <summary>
        /// Добавление нового сообщения в базу данных
        /// </summary>
        /// <param name="message">Сообщение для добавления</param>
        public void AddMessage(Message message)
        {
            DBquery.Execute("INSERT INTO messages (`sender`, `reciever`, `text`) VALUES (" + message.SenderId + ", " + message.RecieverId + ", \"" + message.Text + "\")");
        }

        /// <summary>
        /// Удаление сообщения из базы данных
        /// </summary>
        /// <param name="messageId">Идентификатор сообщение для удаления</param>
        public void DeleteMessage(int messageId)
        {
            DBquery.Execute("DELETE FROM message WHERE id=" + messageId);
        }

        /// <summary>
        /// Получение имени пользователя по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Имя пользователя</returns>
        public string GetUserName(int userId)
        {
            var result = DBquery.Execute("SELECT name FROM users WHERE id=" + userId);

            return (!result.Readable) ? "NONAME" : (string)result.DataResult[0][0];
        }

        /// <summary>
        /// Получение новых сообщений от одного пользователя другому
        /// </summary>
        /// <param name="sender">Пользователь-отправитель</param>
        /// <param name="reciever">Пользователь-получатель</param>
        /// <returns>Список сообщений</returns>
        public IEnumerable<Message> GetMessages(int sender, int reciever)
        {
            var result = DBquery.Execute("SELECT `time`, `text` FROM messages WHERE `reciever`=" + reciever + " AND `sender`=" + sender);
            var messages = result.DataResult.Select(message => new Message(sender, reciever, (DateTime)message[0], (string) message[1])).ToList();

            DBquery.Execute("DELETE FROM messages WHERE `reciever`=" + reciever + " AND `sender`=" + sender);

            return messages;
        }
    }
}