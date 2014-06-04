using MessengerClientLib.MessengerServiceReference;
using MessengerClientLib.Services;
using Moq;
using NUnit.Framework;

namespace MessengerClientTests
{
    [TestFixture]
    public class LoginServiceTests
    {
        [Test]
        public void Login()
        {
            var mock = new Mock<IMessengerService>();
            var loginService = new LoginService(mock.Object);

            loginService.Login("admin");
            mock.Verify(w => w.Login(It.IsAny<string>()));
        }
    }
}
