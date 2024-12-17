using Films.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Films.DAL.EF
{
    public class FilmContext
        : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public FilmContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
