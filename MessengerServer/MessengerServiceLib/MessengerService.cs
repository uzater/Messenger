using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Timers;

namespace MessengerServiceLib
{
    public class MessengerService : IMessengerService
    {
        public int Login(string username)
        {
            using (var connection = new DataBase())
            {
                return connection.Login(username);
            }
        }

        public IEnumerable<User> GetUsers(int userID)
        {
            using (var connection = new DataBase())
            {
                var userList = connection.GetUsers(userID);
                return userList.Where(u => u.Id != userID);
            }
        }

        public void SendMessage(Message message)
        {
            using (var connection = new DataBase())
            {
                if (connection.IfUser(message.UserID) && connection.IfUser(message.DestinationID))
                {
                    connection.AddMessage(message);
                }
            }
        }

        public string GetUserName(int userID)
        {
            using (var connection = new DataBase())
            {
                return connection.GetUserName(userID);
            }
        }
    }
}