using System;

namespace MessengerServiceLib
{
    /// <summary>
    /// Сообщение от одного пользователя к другому
    /// </summary>
    [Serializable]
    public class Message
    {
        /// <summary>
        /// Идентификатор пользователя-отправителя
        /// </summary>
        public readonly int SenderId;

        /// <summary>
        /// Идентификатор пользователя-получателя
        /// </summary>
        public readonly int RecieverId;

        /// <summary>
        /// Время отправки сообщения
        /// </summary>
        public readonly DateTime Time;

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public readonly string Text;

        public Message(int senderId, int recieverId, DateTime time, string text)
        {
            SenderId = senderId;
            RecieverId = recieverId;
            Time = time;
            Text = text;
        }
    }
}