namespace MessengerClientGUI
{
    public class User
    {
        public User(int id, string username, bool online)
        {
            Id = id;
            Username = username;
            Online = online;
        }

        public string Username { get; set; }
        public bool Online { get; set; }
        public int Id { get; set; }
    }
}
