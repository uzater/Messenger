using System;

namespace MessengerClientLib
{
    public interface ILoginForm: IView
    {
        event EventHandler<LoginArgs> LoginAct;
    }
}
