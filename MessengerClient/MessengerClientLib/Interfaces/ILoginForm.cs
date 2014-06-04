using System;
using MessengerClientLib.EventsArgs;

namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Форма для входа
    /// </summary>
    public interface ILoginForm: IView
    {
        /// <summary>
        /// Событие авторизации
        /// </summary>
        event EventHandler<LoginArgs> LoginAct;
    }
}
