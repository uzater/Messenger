using MessengerClientLib;
using MessengerClientLib.MessengerServiceReference;
using NUnit.Framework;

namespace MessengerClientTests
{
    [TestFixture]
    public class ShowedUserTests
    {
        [Test]
        public void ConvertionUserToShowedUser()
        {
            var user = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };
            var showedUser = ShowedUser.From(user);

            Assert.AreEqual("ShowedUser( id: 0 username: Username online new messages: 0 )", showedUser.ToString());
        }
         
    }
}