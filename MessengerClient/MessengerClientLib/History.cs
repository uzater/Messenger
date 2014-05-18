using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib
{
    public class History
    {
        public History(User user)
        {
            User = user;

            Text = "Chat with " + User.Usernamek__BackingField + "\n";
        }

        public User User { get; private set; }
        public string Text { get; private set; }

        public void Add(Message message)
        {
            Text += User.Usernamek__BackingField + " (" + message.Time + "): " + message.Text + "\n";
        }

        public void Add(Message message, string loggedUserName)
        {
            Text += loggedUserName + " (" + message.Time + "): " + message.Text + "\n";
        }
    }
}