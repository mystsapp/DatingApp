namespace DatingApp.API.Helpers
{
    public class MessageParams
    {
        private const int MaxPagesize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPagesize) ? MaxPagesize : value;}
        }

        public int UserId { get; set; } // maybe SenderId or RecipientId
        public string MessageContainer { get; set; } = "Unread";
    }
}