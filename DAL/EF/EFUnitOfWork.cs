using System;
using Microsoft.EntityFrameworkCore;
using Films.DAL.Repositories.Implementations;
using Films.DAL.UnitOfWork;
using Films.DAL.Repositories.Interfaces;

namespace Films.DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private FilmContext db;
        private FilmRepository filmRepository;
        private AdminRepository adminRepository;
        public EFUnitOfWork(DbContextOptions options)
        {
            db = new FilmContext(options);
        }
        public IFilmRepository Films
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepository(db);
                return filmRepository;
            }
        }
        public IAdminRepository Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
