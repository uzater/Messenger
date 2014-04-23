using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MessengerServiceLib
{
    public class DataBase : IDisposable
    {
        private readonly MySqlCommand _command;
        private MySqlDataReader _reader;

        public DataBase()
        {
            _command = new MySqlCommand {Connection = new MySqlConnection("Database=Messenger;Data Source=localhost;User Id=root;Password=pass")};
        }

        private bool CheckUser(string query)
        {
            ExecuteReader(query);

            if (!_reader.Read())
            {
                _command.Connection.Close();
                return false;
            }

            _command.Connection.Close();
            return true;
        }

        private void ExecuteNonQuery(string query)
        {
            _command.CommandText = query;
            _command.Connection.Open();
            _command.ExecuteNonQuery();
        }

        private void ExecuteReader(string query)
        {
            _command.CommandText = query;
            _command.Connection.Open();
            _reader = _command.ExecuteReader();
        }

        public bool IfUser(string username)
        {
            return CheckUser("SELECT * FROM users WHERE name=\"" + username + "\"");
        }

        public bool IfUser(int id)
        {
            return CheckUser("SELECT * FROM users WHERE id=\"" + id + "\"");
        }

        public int Login(string username)
        {
            var query = (IfUser(username))
                ? "UPDATE users SET refreshtime = NOW() WHERE name=\"" + username + "\""
                : "INSERT INTO users (`name`) VALUES (\"" + username + "\")";
            ExecuteNonQuery(query);
            _command.Connection.Close();

            ExecuteReader("SELECT id FROM users WHERE name=\"" + username + "\"");

            if (!_reader.Read())
            {
                _command.Connection.Close();
                return -1;
            }

            var id = _reader.GetInt32(0);
            _command.Connection.Close();
            return id;
        }

        public IEnumerable<User> GetUsers(int userID)
        {
            if (!IfUser(userID))
                return null;

            var result = new List<User>();

            ExecuteReader("SELECT * FROM users");

            while (_reader.Read())
                result.Add(new User(_reader.GetInt32(0), _reader.GetString(1), (Int32)(DateTime.UtcNow.AddHours(4).Subtract(_reader.GetDateTime(2)).TotalSeconds) < 60));

            _command.Connection.Close();
            return result;
        }

        public void Dispose()
        {
            _command.Connection.Close();
        }

        public void AddMessage(Message message)
        {
            ExecuteNonQuery("INSERT INTO messages (`from`, `to`, `text`) VALUES (" + message.UserID + ", " + message.DestinationID + ", \"" + message.Text + "\")");
            _command.Connection.Close();
        }

        public void DeleteMessage(int messageID)
        {
            ExecuteNonQuery("DELETE FROM message WHERE id=" + messageID);
        }

        public string GetUserName(int userID)
        {
            ExecuteReader("SELECT name FROM users WHERE id=" + userID);

            if (!_reader.Read())
            {
                _command.Connection.Close();
                return "Error!";
            }

            var name = _reader.GetString(0);
            _command.Connection.Close();
            return name;
        }

        public IEnumerable<Message> GetMessages(int userId, int fromId)
        {
            ExecuteReader("SELECT `text`, `time` FROM messages WHERE `to`=" + userId + " AND `from`=" + fromId);

            List<Message> messages = new List<Message>();

            while (_reader.Read())
            {
                //TODO: norm time
                messages.Add(new Message(userId, fromId, (Int32)_reader.GetDateTime(1).Ticks, _reader.GetString(0)));
            }
            _command.Connection.Close();

            ExecuteNonQuery("DELETE FROM messages WHERE `to`=" + userId + " AND `from`=" + fromId);

            return messages;
        }
    }
}