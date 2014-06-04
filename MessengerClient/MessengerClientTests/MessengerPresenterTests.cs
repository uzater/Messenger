using System;
using System.Collections.Generic;
using MessengerClientLib;
using MessengerClientLib.EventsArgs;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;
using MessengerClientLib.Presenters;
using Moq;
using NUnit.Framework;
using IMessengerService = MessengerClientLib.Interfaces.IMessengerService;
using Message = MessengerClientLib.MessengerServiceReference.Message;

namespace MessengerClientTests
{
    [TestFixture]
    public class MessengerPresenterTests
    {
        private Mock<IMessengerForm> _view;
        private Mock<IMessengerService> _service;
        private Mock<IApplicationController> _appController; 
        private MessengerPresenter _presenter;

        [SetUp]
        public void Setup()
        {
            _view = new Mock<IMessengerForm>();
            _service = new Mock<IMessengerService>();
            _appController = new Mock<IApplicationController>();
            _presenter = new MessengerPresenter(_appController.Object, _view.Object, _service.Object);
        }

        [Test]
        public void SelectedIndexChangedAct()
        {
            var focusedUser = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };
            _service.Setup(mock => mock.FocusedUser).Returns(focusedUser);

            var histories = new List<History>
            {
                new History(focusedUser)
            };
            _service.Setup(mock => mock.Histories).Returns(histories);


            _view.Raise(mock => mock.SelectedIndexChangedAct += null, null, new SelectedIndexChangedArgs(0));

            _service.Verify(mock => mock.DoSelectedIndexChangeAct(0));
            _view.Verify(mock => mock.StartChatWithUser("Username", "Chat with Username\n"));
        }

        [Test]
        public void SendMessage()
        {
            var focusedUser = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };

            var loggedUser = new User
            {
                Idk__BackingField = 1,
                Usernamek__BackingField = "My Name",
                Onlinek__BackingField = true
            };

            _service.Setup(mock => mock.LoggedUser).Returns(loggedUser);
            _service.Setup(mock => mock.FocusedUser).Returns(focusedUser);

            var histories = new List<History>
            {
                new History(focusedUser)
            };
            _service.Setup(mock => mock.Histories).Returns(histories);

            _view.Raise(mock => mock.SendMessageAct += null, null, new SendMessageArgs("Сообщение"));

            _service.Verify(mock => mock.SendMessage(It.IsAny<Message>()));
            _view.Verify(mock => mock.UpdateHistory(It.IsAny<string>()));
        }


        [Test]
        public void SendEmptyMessage()
        {
            var focusedUser = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };

            var loggedUser = new User
            {
                Idk__BackingField = 1,
                Usernamek__BackingField = "My Name",
                Onlinek__BackingField = true
            };

            _service.Setup(mock => mock.LoggedUser).Returns(loggedUser);
            _service.Setup(mock => mock.FocusedUser).Returns(focusedUser);

            var histories = new List<History>
            {
                new History(focusedUser)
            };
            _service.Setup(mock => mock.Histories).Returns(histories);

            _view.Raise(mock => mock.SendMessageAct += null, null, new SendMessageArgs(""));


            _service.Verify(mock => mock.SendMessage(It.IsAny<Message>()), Times.Never());
            _view.Verify(mock => mock.UpdateHistory(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public void Run()
        {
            var loggedUser = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };
            

            _presenter.Run(loggedUser);

            _service.Verify(mock => mock.SetLoggedUser(loggedUser));
            _service.Verify(mock => mock.Initialize());
            _view.Verify(mock => mock.SetMyName("Username"));
        }

        [Test]
        public void RefreshuserList()
        {
            var loggedUser = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };
            _service.Setup(mock => mock.LoggedUser).Returns(loggedUser);
            var showedUserList = new List<ShowedUser>
            {
                new ShowedUser(loggedUser.Idk__BackingField, loggedUser.Usernamek__BackingField,
                    loggedUser.Onlinek__BackingField, 0)
            };
            _service.Setup(mock => mock.ShowedUserList).Returns(showedUserList);

            _presenter.RefreshUserList(this, new EventArgs());

            _service.Verify(mock => mock.GetUsers(loggedUser.Idk__BackingField));
            _view.Verify(mock => mock.RefreshUserList(showedUserList,-1));
        }

       
         
    }
}