using System;
using System.Windows.Forms;
using MessengerClientLib;
using MessengerClientLib.ApplicationController;
using MessengerClientLib.Interfaces;
using MessengerClientLib.Presenters;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapter())
                           .RegisterView<ILoginForm, LoginForm>()
                           .RegisterView<IMessengerForm, MessengerForm>()
                           .RegisterInstance(new ApplicationContext());

            controller.Run<LoginPresenter>();
        }
    }
}