using System;
using System.Collections.Generic;
using MessengerServiceLib;
using MessengerServiceLib.DataBase;
using Moq;
using NUnit.Framework;

namespace MessengerServiceTests
{
    [TestFixture]
    class DataBaseTests
    {
        [Test]
        public void AddMessage()
        {
            var mock = new Mock<IExecutor>();
            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.AddMessage(new Message(1, 2, DateTime.Now, "test"));

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void IfUserId()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(new List<List<object>>(), true));
            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.IfUser(1);

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void IfUserName()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(new List<List<object>>(), true));
            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.IfUser("admin");

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void Login()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(
                new List<List<object>>
                {
                    new List<object> { 1, "admin", DateTime.Now }, 
                    new List<object> { 2, "test", DateTime.Now }
                }, true));

            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.Login("admin");

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void GetUsers()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(
                new List<List<object>>
                {
                    new List<object> { 1, "admin", DateTime.Now }, 
                    new List<object> { 2, "test", DateTime.Now }
                },
                true));

            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.GetUsers(1);

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void GetUsersNull()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(new List<List<object>>(), false));
            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.GetUsers(1);

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void DeleteMessage()
        {
            var mock = new Mock<IExecutor>();
            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.DeleteMessage(1);

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void GetUserName()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(new List<List<object>>(), false));
            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.GetUserName(1);

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }

        [Test]
        public void GetMessages()
        {
            var mock = new Mock<IExecutor>();
            mock.Setup(o => o.Execute(It.IsAny<string>())).Returns(new DataBaseResult(
                new List<List<object>>
                {
                    new List<object> { DateTime.Now, "test1" },
                    new List<object> { DateTime.Now, "test2" }
                },
                true));

            var dataBase = new DataBase {DBquery = mock.Object};
            dataBase.GetMessages(1, 2);

            mock.Verify(w => w.Execute(It.IsAny<string>()));
        }
    }
}
