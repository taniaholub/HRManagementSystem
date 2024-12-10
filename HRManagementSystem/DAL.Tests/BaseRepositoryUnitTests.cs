using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputUserInstance_CalledAddMethodOfDBSetWithUserInstance()
        {
            // Arrange: організація тестових даних
            DbContextOptions opt = new DbContextOptionsBuilder<HRManagementSystemContext>()
                .Options;

            // Створення двійників для DbContext та DbSet
            var mockContext = new Mock<HRManagementSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();

            mockContext
                .Setup(context => context.Set<User>())
                .Returns(mockDbSet.Object);

            var repository = new BaseRepository<User>(mockContext.Object);
            User expectedUser = new User { IdUser = 1, UserName = "Test User" };

            // Act: виклик методу Create
            repository.Create(expectedUser);

            // Assert: перевірка очікуваної поведінки
            mockDbSet.Verify(
                dbSet => dbSet.Add(expectedUser),
                Times.Once());
        }


        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange: організація тестових даних
            DbContextOptions opt = new DbContextOptionsBuilder<HRManagementSystemContext>()
                .Options;

            // Створення двійників для DbContext та DbSet
            var mockContext = new Mock<HRManagementSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<UserRequest>>();

            mockContext
                .Setup(context => context.Set<UserRequest>())
                .Returns(mockDbSet.Object);

            var repository = new BaseRepository<UserRequest>(mockContext.Object);

            UserRequest expectedRequest = new UserRequest { IdUserRequests = 1, IdUser = 42, CreatedAt = DateTime.Now };

            // Налаштування двійника DbSet для методу Find
            mockDbSet.Setup(dbSet => dbSet.Find(expectedRequest.IdUserRequests))
                     .Returns(expectedRequest);

            // Act: виклик методу Get
            var actualRequest = repository.Get(expectedRequest.IdUserRequests);

            // Assert: перевірка очікуваної поведінки
            mockDbSet.Verify(
                dbSet => dbSet.Find(expectedRequest.IdUserRequests),
                Times.Once());

            Assert.Equal(expectedRequest, actualRequest);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<HRManagementSystemContext>()
                .Options;

            // Створення двійників для DbContext та DbSet
            var mockContext = new Mock<HRManagementSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<UserRequest>>();

            mockContext
                .Setup(context => context.Set<UserRequest>())
                .Returns(mockDbSet.Object);

            var repository = new BaseRepository<UserRequest>(mockContext.Object);

            // Тестовий об'єкт UserRequest
            UserRequest expectedUserRequest = new UserRequest
            {
                IdUserRequests = 1,
                IdUser = 42,
                CreatedAt = DateTime.Now
            };

            // Налаштування двійника DbSet для методу Find
            mockDbSet.Setup(dbSet => dbSet.Find(expectedUserRequest.IdUserRequests))
                     .Returns(expectedUserRequest);

            // Act: виклик методу Delete
            repository.Delete(expectedUserRequest.IdUserRequests);

            // Assert: перевірка очікуваної поведінки
            mockDbSet.Verify(
                dbSet => dbSet.Find(expectedUserRequest.IdUserRequests),
                Times.Once());

            mockDbSet.Verify(
                dbSet => dbSet.Remove(expectedUserRequest),
                Times.Once());
        }
    }
}
