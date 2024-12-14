using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRequestRepository : IRepository<UserRequest>
    {
        IEnumerable<UserRequest> GetRequestsByType(int userId, string requestType);
        IEnumerable<UserRequest> GetRecentRequests(int count);

    }
}
