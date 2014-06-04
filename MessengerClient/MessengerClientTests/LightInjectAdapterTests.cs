using System.Collections;
using MessengerClientLib.ApplicationController;
using MessengerClientLib.MessengerServiceReference;
using Moq;
using NUnit.Framework;
using IMessengerService = MessengerClientLib.MessengerServiceReference.IMessengerService;

namespace MessengerClientTests
{
    [TestFixture]
    class LightInjectAdapterTests
    {
        private Mock<LightInject.IServiceContainer> _container;
        private LightInjectAdapter _adapter;

        [SetUp]
        public void Setup()
        {
            _container = new Mock<LightInject.IServiceContainer>();
            _adapter = new LightInjectAdapter(_container.Object);
        }

        [Test]
        public void RegisterTest()
        {
            _adapter.Register<IMessengerService, MessengerServiceClient>();
            _container.Verify(mock => mock.Register<IMessengerService, MessengerServiceClient>());
        }
        [Test]
        public void RegisterTestFirstParam()
        {
            _adapter.Register<IMessengerService>();
            _container.Verify(mock => mock.Register<IMessengerService>());
        }

        [Test]
        public void RegisterTestSecParam()
        {
            _adapter.RegisterInstance<IEnumerable>(new[] {new List()});
            _container.Verify(mock => mock.RegisterInstance<IEnumerable>(It.IsAny<IEnumerable>()));
        }

        [Test]
        public void RegisterTestDoubleParams()
        {
            _adapter.RegisterInstance<IEnumerable>(new[] { new List() });
            _container.Verify(mock => mock.RegisterInstance<IEnumerable>(It.IsAny<IEnumerable>()));
        }
    }
}
