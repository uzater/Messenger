using System.Collections.Generic;
using MessengerServerLib;

namespace MessengerServiceLib
{
    public class MessengerService : IMessengerService
    {
        public void Login(string username)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers(string username)
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(string username, string destination, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
