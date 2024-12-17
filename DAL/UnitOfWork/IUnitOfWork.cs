using Films.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFilmRepository Films { get; }
        IAdminRepository Admins { get; }
        void Save();
    }
}
