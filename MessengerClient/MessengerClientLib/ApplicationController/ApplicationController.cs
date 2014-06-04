using MessengerClientLib.Interfaces;

namespace MessengerClientLib.ApplicationController
{
    /// <summary>
    /// Контроллер приложения
    /// </summary>
    public class ApplicationController : IApplicationController
    {
        /// <summary>
        /// Контейнер
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        /// Конструктор с контейнером в качестве параметра
        /// </summary>
        /// <param name="container">Контейнер</param>
        public ApplicationController(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
        }

        /// <summary>
        /// Регистрация представления
        /// </summary>
        /// <typeparam name="TView">Представление</typeparam>
        /// <typeparam name="TImplementation">Реализация</typeparam>
        /// <returns></returns>
        public IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <typeparam name="TInstance">Тип зависимости</typeparam>
        /// <param name="instance">Зависимость</param>
        /// <returns>Контроллер приложения</returns>
        public IApplicationController RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }
        /// <summary>
        /// Регистрация сервиса
        /// </summary>
        /// <typeparam name="TModel">Представление</typeparam>
        /// <typeparam name="TImplementation">Реализация</typeparam>
        /// <returns>Контроллер приложения</returns>
        public IApplicationController RegisterService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>();
            return this;
        }

        /// <summary>
        /// Запуск приложения
        /// </summary>
        /// <typeparam name="TPresenter">Тип презентера</typeparam>
        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();
        }

        /// <summary>
        /// Запуск приложения с аргументами
        /// </summary>
        /// <typeparam name="TPresenter">Тип</typeparam>
        /// <typeparam name="TArgumnent">Тип аргументов</typeparam>
        /// <param name="argumnent">Аргументы</param>
        public void Run<TPresenter, TArgumnent>(TArgumnent argumnent) where TPresenter : class, IPresenter<TArgumnent>
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(argumnent);
        }
    }
}