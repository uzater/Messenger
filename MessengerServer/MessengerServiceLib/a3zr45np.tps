using System.Collections.Generic;
using System.ServiceModel;

namespace MessengerServiceLib
{
    [ServiceContract]
    public interface IMessengerService
    {
        [OperationContract]
        void Login(string username);

        [OperationContract]
        User[] GetUsers(string username);

        [OperationContract]
        void SendMessage(string username, string destination, string message);
    }
}