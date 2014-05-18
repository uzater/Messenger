using System.Collections.Generic;
using System.ServiceModel;

namespace MessengerServiceLib
{
    [ServiceContract]
    public interface IMessengerService
    {
        [OperationContract]
        User Login(string username);

        [OperationContract]
        IEnumerable<User> GetUsers(int userID);

        [OperationContract]
        void SendMessage(Message message);

        [OperationContract]
        string GetUserName(int userID);

        [OperationContract]
        IEnumerable<Message> GetMessages(int sender, int reciever);
    }
}