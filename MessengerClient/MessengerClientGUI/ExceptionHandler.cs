using System.Threading;
using System.Windows.Forms;

namespace MessengerClientGUI
{
    internal class ExceptionHandler : IExceptionHandler
    {
        public void Handle(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            if (threadExceptionEventArgs.Exception.InnerException != null && threadExceptionEventArgs.Exception.InnerException.InnerException != null)
            {
                MessageBox.Show(@"Сервер не отвечает, повторите попытку позже.", @"Ошибка приложения");
                Application.ExitThread();
                return;
            }

            MessageBox.Show(
                threadExceptionEventArgs.Exception.InnerException != null
                    ? threadExceptionEventArgs.Exception.InnerException.Message
                    : threadExceptionEventArgs.Exception.Message, @"Ошибка приложения");

            if (threadExceptionEventArgs.Exception.Message != "Пользователь с таким именем уже онлайн!")
                Application.ExitThread();
        }
    }
}
