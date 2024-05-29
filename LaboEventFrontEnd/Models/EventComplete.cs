namespace LaboEventFrontEnd.Models
{
    public class EventComplete : Events
    {
        public List<Themes> Themes { get; set; }
        public List<Comments> comments { get; set; }

        public List<Exposants> exposants { get; set; }
    }
}
