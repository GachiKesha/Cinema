using Films.BLL.Services.Implementations;
using Films.BLL.Services.Interfaces;
using Films.CCL.Security;
using Films.CCL.Security.Identity;
using Films.DAL.UnitOfWork;
using Films.DAL.Entities;
using Films.DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Moq;
using User = Films.CCL.Security.Identity.User;
using Admin = Films.CCL.Security.Identity.Admin;

namespace BLL.Tests
{
    public class FilmServiceTest
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
            () => new FilmService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetFilms_UserIsNotAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Accountant(1, "Zubenko", "Michael", "Petrovich", "mafioznik@ma.fia");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IFilmService filmService = new FilmService(mockUnitOfWork.Object);
            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => filmService.GetFilmsByTitle("Jaws", 0));
        }

        [Fact]
        public void GetStreets_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new Admin(1, "Zubenko", "Michael", "Petrovich", "mafioznik@ma.fia");
            SecurityContext.SetUser(user);
            var filmService = GetFilmService();
            // Act
            var actualfilmDto = filmService.GetFilmsByTitle("testT", 0).First();
            // Assert
            Assert.True(actualfilmDto.FilmID == 1
            && actualfilmDto.Title == "testT"
            && actualfilmDto.Genre == "testG"
            && actualfilmDto.Description == "testD"
            && actualfilmDto.Duration == 2
            );
        }
        IFilmService GetFilmService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedFilm = new Film()
            {
                FilmID = 1,
                Title = "testT",
                Genre = "testG",
                Description = "testD",
                Duration = 2
            };
            var mockDbSet = new Mock<IFilmRepository>();
            mockDbSet.Setup(z =>z.Find(It.IsAny<Func<Film, bool>>(),It.IsAny<int>(),It.IsAny<int>())).Returns(new List<Film>() { expectedFilm });
            mockContext.Setup(context => context.Films).Returns(mockDbSet.Object);
            IFilmService streetService = new FilmService(mockContext.Object);
            return streetService;
        }
    }
}
