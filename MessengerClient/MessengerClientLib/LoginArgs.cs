﻿namespace MessengerClientLib
{
    public class LoginArgs
    {
        public LoginArgs(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}