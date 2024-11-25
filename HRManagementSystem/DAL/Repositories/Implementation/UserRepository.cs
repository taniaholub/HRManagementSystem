using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;


namespace DAL.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }
}
