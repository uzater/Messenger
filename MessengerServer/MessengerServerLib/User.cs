﻿namespace MessengerServerLib
{
    public class User
    {
        public User(string username, bool online)
        {
            Username = username;
            Online = online;
        }

        public string Username { get; set; }
        public bool Online { get; set; }
    }
}