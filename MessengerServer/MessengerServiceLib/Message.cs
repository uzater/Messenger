using System;

namespace MessengerServiceLib
{
    [Serializable]
    public class Message
    {
        public readonly int SenderId;
        public readonly int RecieverId;
        public readonly DateTime Time;
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