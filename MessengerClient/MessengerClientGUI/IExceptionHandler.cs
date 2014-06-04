using System.Threading;

namespace MessengerClientGUI
{
    internal interface IExceptionHandler
    {
        void Handle(object sender, ThreadExceptionEventArgs threadExceptionEventArgs);
    }
}
