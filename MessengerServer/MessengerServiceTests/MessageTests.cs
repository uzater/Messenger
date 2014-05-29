using System;
using MessengerServiceLib;
using NUnit.Framework;

namespace MessengerServiceTests
{
    [TestFixture]
    class MessageTests
    {
        [Test]
        public void CreateMessage()
        {
            var time = DateTime.Now;
            var message = new Message(1, 2, time, "TEST");
            Assert.AreEqual(1, message.SenderId);
            Assert.AreEqual(2, message.RecieverId);
            Assert.AreEqual(time, message.Time);
            Assert.AreEqual("TEST", message.Text);
        }
    }
}
