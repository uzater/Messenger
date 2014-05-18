using System;
using MessengerClientLib.EventsArgs;

namespace MessengerClientLib.Interfaces
{
    public interface ILoginForm: IView
    {
        event EventHandler<LoginArgs> LoginAct;
    }
}
