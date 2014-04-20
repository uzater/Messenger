using System;
using System.Collections.Generic;
using System.Linq;

namespace MessengerServerLib
{
    public class Server
    {
        private readonly List<User> _userlist;

        public Server()
        {
            _userlist = new List<User>();
        }

        public void Login(string username)
        {
            if (_userlist.All(u => u.Username != username))
                _userlist.Add(new User(username, true));
            else
                _userlist.First(u => u.Username == username).Online = true;
        }

        public IEnumerable<User> GetUsers(string username)
        {
            if (_userlist.All(u => u.Username != username))
                throw new Exception("User not found.");

            return _userlist;
        }
    }
}
