using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;


namespace DAL.Repositories.Implementation
{
    public class UserRequestRepository : BaseRepository<UserRequest>, IUserRequestRepository
    {
        public UserRequestRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }

    // Отримати запити користувача за типом
    public IEnumerable<UserRequest> GetRequestsByType(int userId, string requestType)
    {
        return db.UserRequests
                 .Where(r => r.IdUser == userId && r.RequestType == requestType)
                 .ToList();
    }

    // Отримати останні запити всіх користувачів
    public IEnumerable<UserRequest> GetRecentRequests(int count)
    {
        return db.UserRequests.OrderByDescending(r => r.CreatedAt).Take(count).ToList();
    }
}
