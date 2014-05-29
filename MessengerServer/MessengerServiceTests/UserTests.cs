using MessengerServiceLib;
using NUnit.Framework;

namespace MessengerServiceTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void CreateUser()
        {
            var user = new User(1, "admin", true);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("admin", user.Username);
            Assert.AreEqual(true, user.Online);
        }

        [Test]
        public void Equals()
        {
            var user1 = new User(1, "admin", true);
            var user2 = new User(1, "admin", true);

            Assert.IsTrue(user1.Equals(user2));
// ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(user1.Equals(user1));
            Assert.IsFalse(user1.Equals(null));
// ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(user1.Equals(new double()));
        }

        [Test]
        public void _GetHashCode()
        {
            var user1 = new User(1, "admin", true);
            Assert.AreEqual(-2020886245, user1.GetHashCode());
        }
    }
}
