using System.Collections.Generic;

namespace Cinema.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public string Emoji { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            this.Movies = new HashSet<Movie>():
        }
    }
}