namespace LaboEventFrontEnd.Models
{
    public class Events
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
    }
}
