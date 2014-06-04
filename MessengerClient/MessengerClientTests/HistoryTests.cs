using MessengerClientLib;
using MessengerClientLib.MessengerServiceReference;
using NUnit.Framework;

namespace MessengerClientTests
{
    [TestFixture]
    public class HistoryTests
    {
        [Test]
        public void Initialize()
        {
            var usr = new User
            {
                Usernamek__BackingField = "Username"
            };
            var testHistory = new History(usr);

            Assert.AreEqual("Chat with Username\n", testHistory.Text);
        }

        [Test]
        public void AddMyMessage()
        {
            var usr = new User
            {
                Usernamek__BackingField = "Username"
            };
            var testHistory = new History(usr);
            var message = new Message
            {
                SenderId = 1,
                RecieverId = 2,
                Text = "Message text"
            };

            testHistory.Add(message, "myName");

            Assert.AreEqual("Chat with Username\nmyName (01.01.0001 0:00:00): Message text\n", testHistory.Text);
        }

        [Test]
        public void AddInterlocutorMessage()
        {
            var usr = new User
            {
                Usernamek__BackingField = "Username"
            };
            var testHistory = new History(usr);
            var message = new Message
            {
                SenderId = 1,
                RecieverId = 2,
                Text = "Message text"
            };

            testHistory.Add(message);

            Assert.AreEqual("Chat with Username\nUsername (01.01.0001 0:00:00): Message text\n", testHistory.Text);
        }
    }
}