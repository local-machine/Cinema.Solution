using Microsoft.EntityFrameworkCore;

namespace Cinema.Models
{
    public class CinemaContext : DbContext
    {
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        public CinemaContext(DbContextOptions options) : base(options) { }
    }
}
