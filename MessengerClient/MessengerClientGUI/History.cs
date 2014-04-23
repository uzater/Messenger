namespace MessengerClientGUI
{
    public class History
    {
        public History(int userId, string text)
        {
            UserID = userId;
            Text = text;
        }

        public int UserID { get; private set; }
        public string Text { get; set; }
    }
}
