namespace MessengerClientLib
{
    public class History
    {
        public History(int userId, string text)
        {
            UserId = userId;
            Text = text;
        }

        public int UserId { get; private set; }
        public string Text { get; set; }
    }
}