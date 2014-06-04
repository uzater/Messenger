using MessengerClientLib.Interfaces;

namespace MessengerClientLib.Presenters
{
    /// <summary>
    /// Абстрактный класс презентора
    /// </summary>
    /// <typeparam name="TView">Форма, для которой создается презентер</typeparam>
    public abstract class BasePresenter<TView> : IPresenter
           where TView : IView
    {
        /// <summary>
        /// Форма, для которой создается презентер
        /// </summary>
        protected TView View { get; private set; }

        /// <summary>
        /// Контроллер приложения
        /// </summary>
        protected IApplicationController Controller { get; private set; }
        
        /// <summary>
        /// Конструктор презентора
        /// </summary>
        /// <param name="controller">Контроллер приложения</param>
        /// <param name="view">Форма, для которой создается презентер</param>
        protected BasePresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        /// <summary>
        /// Запускаем форму
        /// </summary>
        public void Run()
        {
            View.Show();
        }
    }

    /// <summary>
    /// Абстрактный класс презентера с произвольным типом представления View
    /// </summary>
    /// <typeparam name="TView">Тип представления</typeparam>
    /// <typeparam name="TArg">Тип аргументов</typeparam>
    public abstract class BasePresener<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        /// <summary>
        /// Форма, для которой создается презентер
        /// </summary>
        protected TView View { get; private set; }

        /// <summary>
        /// Контроллер приложения
        /// </summary>
        protected IApplicationController Controller { get; private set; }

        /// <summary>
        /// Конструктор презентора
        /// </summary>
        /// <param name="controller">Контроллер приложения</param>
        /// <param name="view">Форма, для которой создается презентер</param>
        protected BasePresener(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        /// <summary>
        /// Запускаем форму
        /// </summary>
        public abstract void Run(TArg argument);
    }
}