namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Интерфейс для любой формы
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Показать форму
        /// </summary>
        void Show();
        /// <summary>
        /// Закрыть форму
        /// </summary>
        void Close();
    }
}