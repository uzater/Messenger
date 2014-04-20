using System;
using System.Collections.Generic;
using System.Linq;

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
            throw new NotImplementedException();
        }
    }
}