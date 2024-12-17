using Films.DAL.EF;
using Films.DAL.Entities;
using Films.DAL.Repositories.Interfaces;

namespace Films.DAL.Repositories.Implementations
{
    public class FilmRepository
        : BaseRepository<Film>, IFilmRepository
    {
        internal FilmRepository(FilmContext context)
        : base(context)
        {
        }
    }
}
