using System;
using System.Collections.Generic;
using MessengerServiceLib;
using Moq;
using NUnit.Framework;

namespace MessengerServiceTests
{
    [TestFixture]
    class MessengerServiceTests
    {
        [Test]
        public void Login()
        {
            var mock = new Mock<IDataStore>();
            var messengerService = new MessengerService {DataStore = mock.Object};
            messengerService.Login("admin");

            mock.Verify(w => w.Login(It.IsAny<string>()));
        }

        [Test]
        public void LoginException()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.Login(It.IsAny<string>())).Throws(new Exception("Test Exception"));
            var messengerService = new MessengerService {DataStore = mock.Object};

            try
            {
                messengerService.Login("admin");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Test Exception", exception.Message);
            }
        }

        [Test]
        public void GetUsers()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.GetUsers(It.IsAny<int>())).Returns(new List<User> {new User(1, "admin", true), new User(2, "test", false)});
            var messengerService = new MessengerService {DataStore = mock.Object};
            messengerService.GetUsers(1);

            mock.Verify(w => w.GetUsers(It.IsAny<int>()));
        }

        [Test]
        public void GetUsersException()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.GetUsers(It.IsAny<int>())).Throws(new Exception("Test Exception"));
            var messengerService = new MessengerService {DataStore = mock.Object};

            try
            {
                messengerService.GetUsers(1);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Test Exception", exception.Message);
            }
        }

        [Test]
        public void SendMessage()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.IfUser(It.IsAny<int>())).Returns(true);
            var messengerService = new MessengerService {DataStore = mock.Object};
            messengerService.SendMessage(new Message(1, 2, DateTime.Now, "test"));

            mock.Verify(w => w.IfUser(1));
            mock.Verify(w => w.IfUser(2));
            mock.Verify(w => w.AddMessage(It.IsAny<Message>()));
        }

        [Test]
        public void SendMessageException()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.IfUser(It.IsAny<int>())).Returns(false);
            var messengerService = new MessengerService {DataStore = mock.Object};

            try
            {
                messengerService.SendMessage(new Message(1, 2, DateTime.Now, "test"));
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Cann't send message. User not found.", exception.Message);
            }
        }

        [Test]
        public void GetUserName()
        {
            var mock = new Mock<IDataStore>();
            var messengerService = new MessengerService {DataStore = mock.Object};
            messengerService.GetUserName(1);

            mock.Verify(w => w.GetUserName(It.IsAny<int>()));
        }

        [Test]
        public void GetUserNameException()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.GetUserName(It.IsAny<int>())).Throws(new Exception("Test Exception"));
            var messengerService = new MessengerService {DataStore = mock.Object};

            try
            {
                messengerService.GetUserName(1);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Test Exception", exception.Message);
            }
        }

        [Test]
        public void GetMessages()
        {
            var mock = new Mock<IDataStore>();
            var messengerService = new MessengerService {DataStore = mock.Object};
            messengerService.GetMessages(1, 2);

            mock.Verify(w => w.GetMessages(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void GetMessagesException()
        {
            var mock = new Mock<IDataStore>();
            mock.Setup(o => o.GetMessages(It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception("Test Exception"));
            var messengerService = new MessengerService {DataStore = mock.Object};

            try
            {
                messengerService.GetMessages(1, 2);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Test Exception", exception.Message);
            }
        }
    }
}
