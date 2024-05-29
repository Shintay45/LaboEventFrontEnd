namespace LaboEventFrontEnd.Models
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int EventId { get; set; }
        public int PersonId { get; set; }
    }
}
