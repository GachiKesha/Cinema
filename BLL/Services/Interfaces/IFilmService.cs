using Films.BLL.DTO;
using System.Collections.Generic;

namespace Films.BLL.Services.Interfaces
{
    public interface IFilmService
    {
        IEnumerable<FilmDTO> GetFilmsByTitle(string title, int pageNumber, int pageSize = 10);
    }
}


