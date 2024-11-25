using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories.Implementation
{
    public class UserRequestRepository : BaseRepository<UserRequest>, IUserRequestRepository
    {
        public UserRequestRepository(DbContext context) : base(context)
        {
        }
    }
}
