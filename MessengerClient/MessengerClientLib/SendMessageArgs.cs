namespace MessengerClientLib
{
    public class SendMessageArgs
    {
        public SendMessageArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}