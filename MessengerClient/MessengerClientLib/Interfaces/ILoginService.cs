using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Прослойка между презентером формы входа и сетью
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="loginName">Имя для входа</param>
        /// <returns>Пользователь</returns>
        User Login(string loginName);
    }
}