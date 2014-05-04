using System;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib
{
    public class LoginPresenter : BasePresener<ILoginForm>
    {
        public LoginPresenter(IApplicationController controller, ILoginForm view)
            : base(controller, view)
        {
            View.LoginAct += DoLoginAct;
        }

        private void DoLoginAct(object sender, LoginArgs e)
        {
            using (var client = new MessengerServiceClient())
            {
                var loggedUser = client.Login(e.Username);

                if (loggedUser != null)
                {
                    Controller.Run<MessengerPresenter, User>(loggedUser);
                    View.Close();
                }
            }
        }
    }
}