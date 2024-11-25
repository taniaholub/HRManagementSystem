using Catalog.DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
