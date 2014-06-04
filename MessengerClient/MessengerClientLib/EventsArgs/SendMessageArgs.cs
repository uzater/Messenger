namespace MessengerClientLib.EventsArgs
{
    /// <summary>
    /// Аргументы события отправки сообщения
    /// </summary>
    public class SendMessageArgs
    {
        /// <summary>
        /// Конструктор для аргументов события отправки сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        public SendMessageArgs(string message)
        {
            Message = message;
        }
        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }
    }
}