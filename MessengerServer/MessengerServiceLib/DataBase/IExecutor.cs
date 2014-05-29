namespace MessengerServiceLib.DataBase
{
    /// <summary>
    /// Интерфейс для взаимодействия с базой данных
    /// </summary>
    public interface IExecutor
    {
        /// <summary>
        /// Выполнение запроса к базе данных
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Результат запроса</returns>
        DataBaseResult Execute(string query);
    }
}
