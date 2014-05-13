using System;
using System.Collections.Generic;
using System.Linq;

namespace MessengerServiceLib
{
    public class DataBase
    {
        private bool CheckUser(string query)
        {
            var dbquery = new DataBaseQuery();
            var result = dbquery.Execute(query);
            return result.Readable;
        }

        public bool IfUser(string username)
        {
            return CheckUser("SELECT * FROM users WHERE name=\"" + username + "\"");
        }

        public bool IfUser(int id)
        {
            return CheckUser("SELECT * FROM users WHERE id=\"" + id + "\"");
        }

        public User Login(string username)
        {
            var dbquery = new DataBaseQuery();
            var query = (IfUser(username))
                ? "UPDATE users SET refreshtime = NOW() WHERE name=\"" + username + "\""
                : "INSERT INTO users (`name`) VALUES (\"" + username + "\")";
            dbquery.Execute(query);

            var result = dbquery.Execute("SELECT * FROM users WHERE name=\"" + username + "\"");

            return !result.Readable ? null : new User((int)result.DataResult[0][0], (string)result.DataResult[0][1], true);
        }

        public IEnumerable<User> GetUsers(int userID)
        {
            if (!IfUser(userID))
                return null;

            var dbquery = new DataBaseQuery();

            var result = dbquery.Execute("SELECT * FROM users");

            return result.DataResult.Select(user => new User((int) user[0], (string) user[1], (Int32) (DateTime.UtcNow.AddHours(4).Subtract((DateTime) user[2]).TotalSeconds) < 60)).ToList();
        }

        public void AddMessage(Message message)
        {
            var dbquery = new DataBaseQuery();
            dbquery.Execute("INSERT INTO messages (`from`, `to`, `text`) VALUES (" + message.UserID + ", " + message.DestinationID + ", \"" + message.Text + "\")");
        }

        public void DeleteMessage(int messageID)
        {
            var dbquery = new DataBaseQuery();
            dbquery.Execute("DELETE FROM message WHERE id=" + messageID);
        }

        public string GetUserName(int userID)
        {
            var dbquery = new DataBaseQuery();
            var result = dbquery.Execute("SELECT name FROM users WHERE id=" + userID);

            return (!result.Readable) ? "ЕГГОГ!" : (string)result.DataResult[0][0];
        }

        public IEnumerable<Message> GetMessages(int userId, int fromId)
        {
            var dbquery = new DataBaseQuery();
            var result = dbquery.Execute("SELECT `time`, `text` FROM messages WHERE `to`=" + userId + " AND `from`=" + fromId);
            //TODO: time!!!
            var messages = result.DataResult.Select(message => new Message(userId, fromId, (int) 0, (string) message[1])).ToList();

            dbquery.Execute("DELETE FROM messages WHERE `to`=" + userId + " AND `from`=" + fromId);

            return messages;
        }
    }
}