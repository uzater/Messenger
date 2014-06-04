using System;
using System.Collections.Generic;
using MessengerClientLib;
using MessengerClientLib.MessengerServiceReference;
using MessengerClientLib.Services;
using Moq;
using NUnit.Framework;

namespace MessengerClientTests
{
    [TestFixture]
    public class MessengerServiceTests
    {
        private Mock<IMessengerService> _mock;
        private MessengerService _messengerService;
            
        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IMessengerService>();
            _messengerService = new MessengerService(_mock.Object);
        }
        [Test]
        public void SendMessage()
        {
            _messengerService.SendMessage(new Message());
            _mock.Verify(w => w.SendMessage(It.IsAny<Message>()));
        }

        [Test]
        public void GetUsers()
        {
            _messengerService.Initialize();
            _messengerService.GetUsers(1);

            _mock.Setup(mock => mock.GetUsers(It.IsAny<int>()))
                .Returns(new[]
                {new User {Idk__BackingField = 1, Usernamek__BackingField = "admin", Onlinek__BackingField = true}});

            _mock.Verify(w => w.GetUsers(It.IsAny<int>()));
            Assert.AreEqual(0, _messengerService.ShowedUserList.Count);
        }

        [Test]
        public void GetNewMessages()
        {

            _messengerService.Initialize();
            _messengerService.SetLoggedUser(new User {Idk__BackingField = 1, Usernamek__BackingField = "admin", Onlinek__BackingField = true});
            _messengerService.ShowedUserList.Add(new ShowedUser(2, "test", true, 0));
            _messengerService.GetNewMessages(this, new EventArgs());

            _mock.Verify(w => w.GetMessages(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void DoSelectedIndexChangeActTest()
        {
            _messengerService.Initialize();
            _messengerService.SetLoggedUser(new User { Idk__BackingField = 1, Usernamek__BackingField = "admin", Onlinek__BackingField = true });
            _messengerService.ShowedUserList.Add(new ShowedUser(2, "test", true, 0));

            _messengerService.DoSelectedIndexChangeAct(0);
        }

        [Test]
        public void GetNextNewMessageTest()
        {
            _messengerService.Initialize();
            _messengerService.FocusedUser = new ShowedUser(1, "test", true, 0);
            _messengerService.Messages = new List<Message> {new Message {SenderId = 1, RecieverId = 0, Text = "message", Time = DateTime.Now}};
            _messengerService.GetNextNewMessage();
        }

    }
}
