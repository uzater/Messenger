using System.Collections.Generic;

namespace MessengerServiceLib.DataBase
{
    /// <summary>
    /// Результат, возвращаемый базой данных
    /// </summary>
    public class DataBaseResult
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public List<List<object>> DataResult;

        /// <summary>
        /// Признак успешнрго обращения, если TRUE - выполнение запроса прошло успешно
        /// </summary>
        public bool Readable;

        public DataBaseResult(List<List<object>> dataResult, bool readable)
        {
            DataResult = dataResult;
            Readable = readable;
        }
    }
}