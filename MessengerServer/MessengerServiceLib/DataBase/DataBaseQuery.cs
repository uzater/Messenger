using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MessengerServiceLib.DataBase
{
    /// <summary>
    /// Класс для взаимодействия с базой данных
    /// </summary>
    public class DataBaseQuery : IExecutor
    {
        /// <summary>
        /// Отправка запроса к базе данных
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Результат запроса</returns>
        public DataBaseResult Execute(string query)
        {
            var command = new MySqlCommand
            {
                Connection = new MySqlConnection("Database=" + DataBaseConnection.DBName + ";" +
                                                 "Data Source=" + DataBaseConnection.DBHost + ";" +
                                                 "User Id=" + DataBaseConnection.DBUser + ";" +
                                                 "Password=" + DataBaseConnection.DBPass),
                CommandText = query
            };

            command.Connection.Open();

            var reader = command.ExecuteReader();

            var result = new List<List<object>>();
            var readable = false;

            while (reader.Read())
            {
                readable = true;
                var current = new List<object>();

                for(int i = 0; i < reader.FieldCount; ++i)
                    current.Add(reader.GetValue(i));

                result.Add(current);
            }

            command.Connection.Close();

            return new DataBaseResult(result, readable);
        }
    }
}
