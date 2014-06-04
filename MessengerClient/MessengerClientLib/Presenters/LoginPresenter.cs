using MessengerClientLib.EventsArgs;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;
using MessengerClientLib.Services;

namespace MessengerClientLib.Presenters
{
    /// <summary>
    /// Презентер формы для входа
    /// </summary>
    public class LoginPresenter : BasePresenter<ILoginForm>
    {
        /// <summary>
        /// Сервис входа
        /// </summary>
        private readonly ILoginService _loginService;

        /// <summary>
        /// Конструктор презентера для входа
        /// </summary>
        /// <param name="controller">Контроллер приложения</param>
        /// <param name="view">Интерфейс формы</param>
        /// <param name="service"></param>
        public LoginPresenter(IApplicationController controller, ILoginForm view, ILoginService service = null)
            : base(controller, view)
        {
            _loginService = service ?? new LoginService();

            View.LoginAct += DoLoginAct;
        }

        /// <summary>
        /// Обработчик входа в систему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Параметры входа</param>
        private void DoLoginAct(object sender, LoginArgs e)
        {
            var loggedUser = _loginService.Login(e.Username);

            if (loggedUser != null)
            {
                Controller.Run<MessengerPresenter, User>(loggedUser);
                View.Close();
            }
        }
    }
}