using System;

namespace MessengerServiceLib
{
    [Serializable]
    public class Message
    {
        public readonly int UserID;
        public readonly int DestinationID;
        public readonly int Time;
        public readonly string Text;

        public Message(int userID, int destinationID, int time, string text)
        {
            UserID = userID;
            DestinationID = destinationID;
            Time = time;
            Text = text;
        }
    }
}