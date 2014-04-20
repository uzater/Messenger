﻿using System.Collections.Generic;
using System.ServiceModel;

namespace MessengerServiceLib
{
    [ServiceContract]
    public interface IMessengerService
    {
        [OperationContract]
        int Login(string username);

        [OperationContract]
        IEnumerable<User> GetUsers(int userID);

        [OperationContract]
        void SendMessage(Message message);
    }
}