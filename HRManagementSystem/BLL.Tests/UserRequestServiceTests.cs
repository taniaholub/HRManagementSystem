using Moq;
using BLL.Services.Interfaces;
using BLL.Services.Impl;
using CCL.Security.Identity;
using CCL.Security;
using DAL.Repositories.Interfaces;
using DAL.Entities;
using DAL.Enums;
using DAL.UnitOfWork;

namespace BLL.Tests
{
    public class UserRequestServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork? nullUnitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new UserRequestService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetUserRequests_UserIsEmployee_ThrowMethodAccessException()
        {
            // Arrange
            var user = new Employee(1, "test");
            SecurityContext.SetUser(user);

            var mockUserRequestRepo = new Mock<IUserRequestRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.UserRequests).Returns(mockUserRequestRepo.Object);

            IUserRequestService userRequestService = new UserRequestService(mockUnitOfWork.Object);

            // Act & Assert
            Assert.Throws<MethodAccessException>(() => userRequestService.GetUserRequests(0));
        }

        [Fact]
        public void GetUserRequests_UserRequestFromDAL_CorrectMappingToUserRequestDTO()
        {
            // Arrange
            var user = new HR(1, "test");
            SecurityContext.SetUser(user);

            var userRequestService = GetUserRequestService();

            // Act
            var actualUserRequestDto = userRequestService.GetUserRequests(0).First();

            // Assert
            Assert.True(
                actualUserRequestDto.IdUserRequests == 1 &&
                actualUserRequestDto.IdUser == 2 &&
                actualUserRequestDto.RequestType == RequestType.Vacation &&
                actualUserRequestDto.CreatedAt == new DateTime(2024, 1, 1)
            );
        }

        private IUserRequestService GetUserRequestService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedRequest = new UserRequest
            {
                IdUserRequests = 1,
                IdUser = 2,
                RequestType = RequestType.Vacation,
                CreatedAt = new DateTime(2024, 1, 1)
            };

            var mockDbSet = new Mock<IUserRequestRepository>();
            mockDbSet
                .Setup(repo =>
                    repo.Find(It.IsAny<Func<UserRequest, bool>>()))
                .Returns(new List<UserRequest> { expectedRequest });

            mockContext
                .Setup(context => context.UserRequests)
                .Returns(mockDbSet.Object);

            IUserRequestService userRequestService = new UserRequestService(mockContext.Object);
            return userRequestService;
        }
    }
}