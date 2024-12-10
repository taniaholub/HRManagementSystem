using DAL.Entities;
using DAL.EF;
using DAL.Enums;
using DAL.Repositories.Implementation;
using Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DAL.Tests
{
    public class TestUserRepository
    {
        // Тест для методу GetUsersByRole
        [Fact]
        public void GetUsersByRole_InputRole_ReturnsUsersWithMatchingRole()
        {
            // Arrange: ініціалізація тестових даних
            var options = new DbContextOptionsBuilder<HRManagementSystemContext>()
                .Options;

            // Створення мок-об'єкта для контексту бази даних
            var mockContext = new Mock<HRManagementSystemContext>(options);

            // Створення мок-об'єкта для DbSet<User>
            var mockDbSet = new Mock<DbSet<User>>();

            // Список користувачів, що буде використовуватися для тесту
            var users = new List<User>
            {
                new User { IdUser = 1, Email = "user1@example.com", Roles = new List<Role> { Role.HR } },
                new User { IdUser = 2, Email = "user2@example.com", Roles = new List<Role> { Role.Employee } },
                new User { IdUser = 3, Email = "user3@example.com", Roles = new List<Role> { Role.HR } }
            }.AsQueryable();

            // Налаштовуємо мок-об'єкт DbSet так, щоб він повертав список користувачів
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            // Налаштовуємо мок-об'єкт контексту так, щоб він повертав мок-DbSet
            mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);

            // Створюємо екземпляр репозиторію
            var repository = new UserRepository(mockContext.Object);
            string role = "HR";  // Тестуємо роль "HR"

            // Act: виклик методу для отримання користувачів з цією роллю
            var result = repository.GetUsersByRole(role);

            // Assert: перевірка, чи метод повернув правильну кількість користувачів
            Assert.Equal(2, result.Count()); // Оскільки є два користувачі з роллю "HR"
        }

        // Тест для методу FindByEmail
        [Fact]
        public void FindByEmail_InputEmail_ReturnsUserWithMatchingEmail()
        {
            // Arrange: ініціалізація тестових даних
            var options = new DbContextOptionsBuilder<HRManagementSystemContext>()
                .Options;

            // Створення мок-об'єкта для контексту бази даних
            var mockContext = new Mock<HRManagementSystemContext>(options);

            // Створення мок-об'єкта для DbSet<User>
            var mockDbSet = new Mock<DbSet<User>>();

            // Список користувачів, що буде використовуватися для тесту
            var users = new List<User>
            {
                new User { IdUser = 1, Email = "user1@example.com" },
                new User { IdUser = 2, Email = "user2@example.com" }
            }.AsQueryable();

            // Налаштовуємо мок-об'єкт DbSet так, щоб він повертав список користувачів
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            // Налаштовуємо мок-об'єкт контексту так, щоб він повертав мок-DbSet
            mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);

            // Створюємо екземпляр репозиторію
            var repository = new UserRepository(mockContext.Object);
            string email = "user1@example.com";  // Тестуємо email користувача

            // Act: виклик методу для пошуку користувача за електронною поштою
            var result = repository.FindByEmail(email);

            // Assert: перевірка, чи метод повернув правильного користувача
            Assert.NotNull(result); // Користувач має бути знайдений
            Assert.Equal("user1@example.com", result.Email); // Перевірка електронної пошти
        }

        // Тест для методу GetActiveUsers
        [Fact]
        public void GetActiveUsers_InputFromDate_ReturnsUsersWhoHaveRequestsAfterFromDate()
        {
            // Arrange: ініціалізація тестових даних
            var options = new DbContextOptionsBuilder<HRManagementSystemContext>()
                .Options;

            // Створення мок-об'єкта для контексту бази даних
            var mockContext = new Mock<HRManagementSystemContext>(options);

            // Створення мок-об'єкта для DbSet<User>
            var mockDbSet = new Mock<DbSet<User>>();

            // Список користувачів, що буде використовуватися для тесту
            var users = new List<User>
            {
                new User { IdUser = 1, Email = "user1@example.com", UserRequests = new List<UserRequest> { new UserRequest { CreatedAt = DateTime.Now.AddDays(-5) } } },
                new User { IdUser = 2, Email = "user2@example.com", UserRequests = new List<UserRequest> { new UserRequest { CreatedAt = DateTime.Now.AddDays(-10) } } }
            }.AsQueryable();

            // Налаштовуємо мок-об'єкт DbSet так, щоб він повертав список користувачів
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            // Налаштовуємо мок-об'єкт контексту так, щоб він повертав мок-DbSet
            mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);

            // Створюємо екземпляр репозиторію
            var repository = new UserRepository(mockContext.Object);
            DateTime fromDate = DateTime.Now.AddDays(-7); // Тестуємо дату, після якої мають бути знайдені користувачі

            // Act: виклик методу для отримання активних користувачів
            var result = repository.GetActiveUsers(fromDate);

            // Assert: перевірка, що метод повернув правильного користувача
            Assert.Single(result); // Лише один користувач має запит після вказаної дати
            Assert.Equal("user1@example.com", result.First().Email); // Перевірка електронної пошти першого користувача
        }
    }
}
