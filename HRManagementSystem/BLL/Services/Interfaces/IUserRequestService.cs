﻿using BLL.DTO;
using System.Collections.Generic;


namespace BLL.Services.Interfaces
{
    public interface IUserRequestService
    {
        IEnumerable<UserDTO> GetUsersByRole(string role);
        UserDTO GetUserById(int userId);
        IEnumerable<UserRequestDTO> GetUserRequests(int userId);
    }
}


