using MessengerClientLib.ApplicationController;
using MessengerClientLib.Interfaces;
using Moq;
using NUnit.Framework;

namespace MessengerClientTests
{
    [TestFixture]
    public class ApplicationPresenterTests
    {
        private Mock<IContainer> _container;
        private ApplicationController _appController;
        
        [SetUp]
        public void Setup()
        {
            _container = new Mock<IContainer>();
            _appController = new ApplicationController(_container.Object);
        }

        [Test]
        public void RegisterViewTest()
        {
            _appController.RegisterView<ILoginForm, ILoginForm>();

            _container.Verify(mock => mock.Register<ILoginForm, ILoginForm>());
        }

        [Test]
        public void RegisterServiceTest()
        {
            _appController.RegisterService<ILoginService, ILoginService>();

            _container.Verify(mock => mock.Register<ILoginService, ILoginService>());
        }
    }
}