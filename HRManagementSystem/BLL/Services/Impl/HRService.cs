using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using DAL.Entities;
using BLL.DTO;

namespace BLL.Services.Impl
{
    public class HRService : IHRService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HRService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<UserDTO> GetUsersByRole(string role)
        {
            var users = _unitOfWork.Users.GetUsersByRole(role);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _unitOfWork.Users.Get(userId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public IEnumerable<UserRequestDTO> GetUserRequests(int userId)
        {
            var requests = _unitOfWork.UserRequests.Find(r => r.IdUser == userId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserRequest, UserRequestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserRequest>, List<UserRequestDTO>>(requests);
        }
    }
}
