using System;
using System.Windows.Forms;
using MessengerClientLib.ApplicationController;
using MessengerClientLib.Interfaces;
using MessengerClientLib.Presenters;
using MessengerClientLib.Services;

namespace MessengerClientGUI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            Application.ThreadException += exceptionHandler.Handle;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapter())
                           .RegisterView<ILoginForm, LoginForm>()
                           .RegisterService<ILoginService, LoginService>()
                           .RegisterView<IMessengerForm, MessengerForm>()
                           .RegisterService<IMessengerService, MessengerService>()
                           .RegisterInstance(new ApplicationContext());

            controller.Run<LoginPresenter>();
        }
    }
}