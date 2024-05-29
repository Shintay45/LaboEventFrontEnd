namespace LaboEventFrontEnd.Models
{
    public class EventComplete : Events
    {
        public List<Themes> Themes { get; set; }
        public List<Comments> comments { get; set; }

        public List<Exposant_d> exposant_Ds { get; set; }
    }
}
