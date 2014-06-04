namespace MessengerClientLib.EventsArgs
{
    /// <summary>
    /// Аргументы для события входа
    /// </summary>
    public class LoginArgs
    {
        /// <summary>
        /// Констркутор для аргументов события входа
        /// </summary>
        /// <param name="username">Имя пользователя под которым пытаемся войти</param>
        public LoginArgs(string username)
        {
            Username = username;
        }
        /// <summary>
        /// Имя пользователя под которым пытаемся войти
        /// </summary>
        public string Username { get; set; }
    }
}