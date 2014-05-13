﻿using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MessengerServiceLib
{
    public class DataBaseQuery
    {
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
