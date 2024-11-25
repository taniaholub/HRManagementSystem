using DAL.Repositories.Interfaces;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories.Implementation
{
    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(DbContext context) : base(context)
        {
        }
    }
}
