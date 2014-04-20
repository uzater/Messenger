using System;

namespace MessengerServiceLib
{
    [Serializable]
    public class Message
    {
        public readonly int _userID;
        public readonly int _destinationID;

        public Message(int userID, int destinationID)
        {
            _userID = userID;
            _destinationID = destinationID;
        }
    }
}