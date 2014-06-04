using System.Threading;
using System.Windows.Forms;

namespace MessengerClientGUI
{
    internal class ExceptionHandler : IExceptionHandler
    {
        public void Handle(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            MessageBox.Show(threadExceptionEventArgs.Exception.Message, @"Application error");
        }
    }
}
