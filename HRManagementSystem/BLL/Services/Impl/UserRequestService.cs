using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<UserDTO> GetUsersByRole(string role)
        {
            var users = _unitOfWork.Users.GetUsersByRole(role);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Entities.User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DAL.Entities.User>, List<UserDTO>>(users);
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _unitOfWork.Users.Get(userId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Entities.User, UserDTO>()).CreateMapper();
            return mapper.Map<DAL.Entities.User, UserDTO>(user);
        }

        public IEnumerable<UserRequestDTO> GetUserRequests(int userId)
        {
            var currentUser = SecurityContext.GetUser();
            if (currentUser == null || !(currentUser is HR))
            {
                throw new MethodAccessException("Access denied for non-HR users.");
            }

            var requests = _unitOfWork.UserRequests.Find(r => r.IdUser == userId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserRequest, UserRequestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserRequest>, List<UserRequestDTO>>(requests);
        }
    }
}