﻿using DAL.Entities;


namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUsersByRole(string role);
        User FindByEmail(string email);
        IEnumerable<User> GetActiveUsers(DateTime fromDate);
    }
}


