using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories.Implementation
{
    public class VacationRequestRepository : BaseRepository<VacationRequest>, IVacationRequestRepository
    {
        public VacationRequestRepository(DbContext context) : base(context)
        {
        }
    }
}
