using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementation
{
    public class UserRequestRepository : BaseRepository<UserRequest>, IUserRequestRepository
    {
        public UserRequestRepository(HRManagementSystemContext context) : base(context)
        {
        }

        // Отримати запити користувача за типом
        public IEnumerable<UserRequest> GetRequestsByType(int userId, string requestType)
        {
            return _dbSet
                .Where(r => r.IdUser == userId && r.RequestType.ToString() == requestType)
                .ToList();
        }

        // Отримати останні запити всіх користувачів
        public IEnumerable<UserRequest> GetRecentRequests(int count)
        {
            return _dbSet
                .OrderByDescending(r => r.CreatedAt)
                .Take(count)
                .ToList();
        }
    }
}
