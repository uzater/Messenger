using System;

namespace MessengerServiceLib
{
    [Serializable]
    public class Message
    {
        public readonly int UserID;
        public readonly int DestinationID;
        public readonly string Text;

        public Message(int userID, int destinationID, string text)
        {
            UserID = userID;
            DestinationID = destinationID;
            Text = text;
        }
    }
}