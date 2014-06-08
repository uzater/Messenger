using System.Windows.Forms;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Services
{
    /// <summary>
    /// Сервис входа
    /// </summary>
    public class LoginService: ILoginService
    {
        /// <summary>
        /// Клиент
        /// </summary>
        public MessengerServiceReference.IMessengerService Client;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LoginService()
        {
            Client = new MessengerServiceClient();
        }

        /// <summary>
        /// Конструктор, принимающий в качестве парамета клиент
        /// </summary>
        /// <param name="client">Клиент</param>
        public LoginService(MessengerServiceReference.IMessengerService client)
        {
            Client = client;
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="loginName">Имя пользователя для входа</param>
        /// <returns>Пользователь</returns>
        public User Login(string loginName)
        {
            return Client.Login(loginName);
        }
    }
}