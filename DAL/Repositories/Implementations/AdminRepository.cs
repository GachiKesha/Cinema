using Films.DAL.EF;
using Films.DAL.Entities;
using Films.DAL.Repositories.Interfaces;

namespace Films.DAL.Repositories.Implementations
{
    public class AdminRepository
        : BaseRepository<Admin>, IAdminRepository
    {
        internal AdminRepository(FilmContext context)
        : base(context)
        {
        }
    }
}
