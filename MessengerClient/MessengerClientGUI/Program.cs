using System;
using System.Windows.Forms;
using MessengerClientLib;

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

            var loginForm = new LoginForm();
            var messengerForm = new MessengerForm();
            var presenter = new Presenter(loginForm, messengerForm);

            loginForm.Closed += delegate
            {
                Application.Run(messengerForm);
            };

            Application.Run(loginForm);
        }
    }
}