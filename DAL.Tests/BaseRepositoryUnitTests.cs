using Xunit;
using Moq;
using Films.DAL.Entities;
using Films.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Films.DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputAdminInstance_CalledAddMethodOfDBSetWithAdminInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FilmContext>()
            .Options;
            var mockContext = new Mock<FilmContext>(opt);
            var mockDbSet = new Mock<DbSet<Admin>>();
            mockContext.Setup(context => context.Set<Admin>()).Returns(mockDbSet.Object);
            var repository = new TestAdminRepository(mockContext.Object);
            Admin expectedAdmin = new Mock<Admin>().Object;
            //Act
            repository.Create(expectedAdmin);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expectedAdmin), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FilmContext>().Options;
            var mockContext = new Mock<FilmContext>(opt);
            var mockDbSet = new Mock<DbSet<Admin>>();
            mockContext.Setup(context =>context.Set<Admin>()).Returns(mockDbSet.Object);
            Admin expectedAdmin = new Admin() { UserID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedAdmin.UserID)).Returns(expectedAdmin);
            var repository = new TestAdminRepository(mockContext.Object);
            //Act
            var actualAdmin = repository.Get(expectedAdmin.UserID);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedAdmin.UserID), Times.Once());
            Assert.Equal(expectedAdmin, actualAdmin);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FilmContext>()
            .Options;
            var mockContext = new Mock<FilmContext>(opt);
            var mockDbSet = new Mock<DbSet<Admin>>();
            mockContext
            .Setup(context =>
            context.Set<Admin>(
            ))
            .Returns(mockDbSet.Object);
            var repository = new TestAdminRepository(mockContext.Object);
            Admin expectedAdmin = new Admin() { UserID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedAdmin.UserID)).Returns(expectedAdmin);
            //Act
            repository.Delete(expectedAdmin.UserID);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedAdmin.UserID), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedAdmin), Times.Once());
        }
    }
}
