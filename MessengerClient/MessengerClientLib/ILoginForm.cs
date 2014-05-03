using System;

namespace MessengerClientLib
{
    public interface ILoginForm
    {
        event EventHandler<LoginArgs> LoginAct; 
    }
}
