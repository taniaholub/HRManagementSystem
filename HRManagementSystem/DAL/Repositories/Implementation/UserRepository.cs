using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HRManagementSystemContext context) : base(context)
        {
        }

        // Отримати список користувачів за роллю
        public IEnumerable<User> GetUsersByRole(string role)
        {
            return _dbSet.Where(user => user.Roles.Any(r => r.ToString() == role)).ToList();
        }


        // Знайти користувача за електронною поштою
        public User FindByEmail(string email)
        {
            return _dbSet.FirstOrDefault(user => user.Email == email);
        }

        // Отримати користувачів, які створили запити за останній місяць
        public IEnumerable<User> GetActiveUsers(DateTime fromDate)
        {
            return _dbSet
                .Where(user => user.UserRequests.Any(req => req.CreatedAt >= fromDate))
                .ToList();
        }
    }
}
