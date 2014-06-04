namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Интерфейс контроллера приложения
    /// </summary>
    public interface IApplicationController
    {
        /// <summary>
        /// Регистрация представления
        /// </summary>
        /// <typeparam name="TView">Представление</typeparam>
        /// <typeparam name="TImplementation">Реализация</typeparam>
        /// <returns></returns>
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <typeparam name="TInstance">Тип зависимости</typeparam>
        /// <param name="instance">Зависимость</param>
        /// <returns>Контроллер приложения</returns>
        IApplicationController RegisterInstance<TInstance>(TInstance instance);

        /// <summary>
        /// Регистрация сервиса
        /// </summary>
        /// <typeparam name="TService">Представление</typeparam>
        /// <typeparam name="TImplementation">Реализация</typeparam>
        /// <returns>Контроллер приложения</returns>
        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        /// <summary>
        /// Запуск приложения
        /// </summary>
        /// <typeparam name="TPresenter">Тип презентера</typeparam>
        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        /// <summary>
        /// Запуск приложения с аргументами
        /// </summary>
        /// <typeparam name="TPresenter">Тип</typeparam>
        /// <typeparam name="TArgumnent">Тип аргументов</typeparam>
        /// <param name="argumnent">Аргументы</param>
        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}