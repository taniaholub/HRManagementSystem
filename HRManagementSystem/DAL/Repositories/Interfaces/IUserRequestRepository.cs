using DAL.Entities;


namespace DAL.Repositories.Interfaces
{
    public interface IUserRequestRepository : IRepository<UserRequest>
    {
        IEnumerable<UserRequest> GetRequestsByType(int userId, string requestType);
        IEnumerable<UserRequest> GetRecentRequests(int count);
    }
}
