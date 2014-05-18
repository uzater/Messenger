using System.Security.Cryptography;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib
{
    public class ShowedUser : User
    {
        public int NewMessagesCount { get; set; }

        public ShowedUser(int id, string name, bool online, int newMessagesCount)
        {
            Idk__BackingField = id;
            Usernamek__BackingField = name;
            Onlinek__BackingField = online;
            NewMessagesCount = newMessagesCount;
        }

        public static ShowedUser From(User user)
        {
            return new ShowedUser(user.Idk__BackingField, user.Usernamek__BackingField, user.Onlinek__BackingField, 0);
        }
    }
}