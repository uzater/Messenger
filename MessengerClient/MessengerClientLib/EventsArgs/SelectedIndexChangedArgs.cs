namespace MessengerClientLib
{
    public class SelectedIndexChangedArgs
    {
        public SelectedIndexChangedArgs(int position)
        {
            Position = position;
        }

        public int Position { get; set; }

        public string Username { get; set; }
    }
}