﻿using System;
using System.Dynamic;

namespace MessengerServiceLib.DataBase
{
    /// <summary>
    /// Конфигурация базы данных
    /// </summary>
    public class DataBaseConnection
    {
        /// <summary>
        /// Имя базы данных
        /// </summary>
        public static string DBName { get; set; }

        /// <summary>
        /// Хост
        /// </summary>
        public static string DBHost { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public static string DBUser { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public static string DBPass { get; set; }

        /// <summary>
        /// Префикс таблиц
        /// </summary>
        public static string DBPrefix { get; set; }
        
    }
}
