using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using DAL.Entities;
using BLL.DTO;
using CCL.Security.Identity;
using CCL.Security;

namespace BLL.Services.Impl
{
    public class UserRequestService : IUserRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<UserDTO> GetUsersByRole(string role)
        {
            var currentUser = SecurityContext.GetUser();
            var userType = currentUser.GetType();

            // Перевірка доступу
            if (userType != typeof(HR))
            {
                throw new MethodAccessException("Access denied for non-Director and non-Accountant users.");
            }

            // Отримання даних із репозиторію
            var usersEntities = _unitOfWork.Users.GetUsersByRole(role);

            // Налаштування мапера
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Entities.User, UserDTO>()).CreateMapper();

            // Мапінг сутностей у DTO
            var usersDto = mapper.Map<IEnumerable<DAL.Entities.User>, List<UserDTO>>(usersEntities);

            return usersDto;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<UserRequestDTO> GetUserRequests(int userId)
        {
            var currentUser = SecurityContext.GetUser();
            if (currentUser == null || currentUser.GetType() != typeof(HR))
            {
                throw new MethodAccessException("Access denied for non-HR users.");
            }

            // Отримання даних із репозиторію
            var requestsEntities = _unitOfWork.UserRequests.Find(r => r.IdUser == userId);

            // Налаштування мапера
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserRequest, UserRequestDTO>()).CreateMapper();

            // Мапінг сутностей у DTO
            var requestsDto = mapper.Map<IEnumerable<UserRequest>, List<UserRequestDTO>>(requestsEntities);

            return requestsDto;
        }

        public UserDTO GetUserById(int userId)
        {
            var currentUser = SecurityContext.GetUser();

            // Отримання користувача
            var userEntity = _unitOfWork.Users.Get(userId);

            // Налаштування мапера
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Entities.User, UserDTO>()).CreateMapper();

            // Мапінг у DTO
            var userDto = mapper.Map<DAL.Entities.User, UserDTO>(userEntity);

            return userDto;
        }
    }
}
