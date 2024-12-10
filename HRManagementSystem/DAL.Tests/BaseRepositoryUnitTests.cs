using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Xunit;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void MockContextTest()
        {
            // Створення макету DbSet
            var mockDbSet = new Mock<DbSet<User>>();

            // Створення макету DbContext
            var mockContext = new Mock<HRManagementSystemContext>();
            mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);

            // Перевірка
            Assert.NotNull(mockContext.Object);
        }
    }
}
