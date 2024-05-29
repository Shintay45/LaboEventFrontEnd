namespace LaboEventFrontEnd.Models
{
    public class Exposants
    {
        public int PersonEventId { get; set; }
        public int PersonId { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Gsm { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }
    }
}
