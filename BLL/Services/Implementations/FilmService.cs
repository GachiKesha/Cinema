using AutoMapper;
using Films.BLL.DTO;
using Films.BLL.Services.Interfaces;
using Films.CCL.Security;
using Films.CCL.Security.Identity;
using Films.DAL.Entities;
using Films.DAL.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Films.BLL.Services.Implementations
{
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public FilmService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<FilmDTO> GetFilmsByTitle(string title, int pageNumber, int pageSize)
        {
            var user = SecurityContext.GetUser();
            if (user.GetType() != typeof(CCL.Security.Identity.Admin))
            {
                throw new MethodAccessException();
            }
            var filmEntities = _database.Films.Find(f => f.Title.Contains(title, StringComparison.OrdinalIgnoreCase), pageNumber, pageSize);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Film, FilmDTO>()).CreateMapper();
            var filmDto = mapper.Map<IEnumerable<Film>, List<FilmDTO>>(filmEntities);
            return filmDto;
        }
    }
}