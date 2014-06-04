namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Интерфейс презентера
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// Запуск приложения
        /// </summary>
        void Run();
    }

    /// <summary>
    /// Интерфейс презентера от аргумента
    /// </summary>
    public interface IPresenter<in TArg>
    {
        /// <summary>
        /// Запуск с аргументами
        /// </summary>
        /// <param name="argument">Аргументы</param>
        void Run(TArg argument);
    }
}