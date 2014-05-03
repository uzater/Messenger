namespace MessengerClientLib
{
    public class SelectedIndexChangedArgs
    {
        public SelectedIndexChangedArgs(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}