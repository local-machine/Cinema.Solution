namespace Cinema.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MPAARating { get; set; }
        public string PublicRating { get; set; }
        public int Runtime { get; set; }

        public string Emoji { get; set; }

        public virtual Genre Genre { get; set; }
    }
}