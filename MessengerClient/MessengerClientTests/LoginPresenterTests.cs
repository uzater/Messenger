using MessengerClientLib.EventsArgs;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;
using MessengerClientLib.Presenters;
using Moq;
using NUnit.Framework;

namespace MessengerClientTests
{
    [TestFixture]
    public class LoginPresenterTests
    {
        private Mock<ILoginForm> _view;
        private Mock<ILoginService> _proxy;
        private Mock<IApplicationController> _appController; 
        private LoginPresenter _presenter;


        [SetUp]
        public void Setup()
        {
            _view = new Mock<ILoginForm>();
            _proxy = new Mock<ILoginService>();
            _appController = new Mock<IApplicationController>();
            _presenter = new LoginPresenter(_appController.Object, _view.Object, _proxy.Object);
        }

        [Test]
        public void Login()
        {
            var loggedUser = new User
            {
                Idk__BackingField = 0,
                Usernamek__BackingField = "Username",
                Onlinek__BackingField = true
            };

            _proxy.Setup(mock => mock.Login("admin")).Returns(loggedUser);

            _view.Raise(mock => mock.LoginAct += null, null, new LoginArgs("admin"));

            _appController.Verify(mock => mock.Run<MessengerPresenter, User>(loggedUser));
            _view.Verify(mock => mock.Close());
        }

        [Test]
        public void RunTestOfAbstractClassBasePresenter()
        {
            _presenter.Run();

            _view.Verify(mock => mock.Show());
        }
         
    }
}