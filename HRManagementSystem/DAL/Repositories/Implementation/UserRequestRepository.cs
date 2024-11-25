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
}
