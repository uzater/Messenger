using System.Collections.Generic;
using System.Linq;

namespace MessengerServiceLib
{
    public class MessengerService : IMessengerService
    {
        public User Login(string username)
        {
            var connection = new DataBase();
            return connection.Login(username);
        }

        public IEnumerable<User> GetUsers(int userID)
        {
            var connection = new DataBase();
            var userList = connection.GetUsers(userID);
            return userList.Where(u => u.Id != userID);
        }

        public void SendMessage(Message message)
        {
            var connection = new DataBase();
            if (connection.IfUser(message.UserID) && connection.IfUser(message.DestinationID))
                connection.AddMessage(message);
        }

        public string GetUserName(int userID)
        {
            var connection = new DataBase();
            return connection.GetUserName(userID);
        }

        public IEnumerable<Message> GetMessages(int userID, int fromID)
        {
            var connection = new DataBase();
            return connection.GetMessages(userID, fromID);
        }
    }
}