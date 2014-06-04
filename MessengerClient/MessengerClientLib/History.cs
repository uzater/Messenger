using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib
{
    /// <summary>
    /// История сообщений
    /// </summary>
    public class History
    {
        public History(User user)
        {
            User = user;

            Text = "Chat with " + User.Usernamek__BackingField + "\n";
        }
        /// <summary>
        /// Позьзователь с которым ведется история сообщений
        /// </summary>
        public User User { get; private set; }
        /// <summary>
        /// Сама история сообщений
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// Метод для добавления в историю сообщения от собеседника
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Add(Message message)
        {
            Text += User.Usernamek__BackingField + " (" + message.Time + "): " + message.Text + "\n";
        }
        /// <summary>
        /// Метод для добавления в историю собственных сообщений
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="loggedUserName">Собственное имя</param>
        public void Add(Message message, string loggedUserName)
        {
            Text += loggedUserName + " (" + message.Time + "): " + message.Text + "\n";
        }
    }
}