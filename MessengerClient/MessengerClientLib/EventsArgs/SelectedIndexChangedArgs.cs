namespace MessengerClientLib.EventsArgs
{
    /// <summary>
    /// Аргументы события выбора пользователя
    /// </summary>
    public class SelectedIndexChangedArgs
    {
        /// <summary>
        /// Конструктор для аргументов события выбора пользователя
        /// </summary>
        /// <param name="position">Псеводо id пользователя</param>
        public SelectedIndexChangedArgs(int position)
        {
            Position = position;
        }

        /// <summary>
        /// Псеводо id пользователя
        /// </summary>
        public int Position { get; set; }
    }
}