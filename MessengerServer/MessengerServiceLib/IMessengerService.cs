using System.Collections.Generic;
using System.ServiceModel;
using MessengerServerLib;

namespace MessengerServiceLib
{
    [ServiceContract]
    public interface IMessengerService
    {
        [OperationContract]
        void Login(string username);

        [OperationContract]
        IEnumerable<User> GetUsers(string username);

        [OperationContract]
        void SendMessage(string username, string destination, string message);
    }
}
