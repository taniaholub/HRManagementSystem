using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;


namespace DAL.Repositories.Implementation
{
    public class VacationRequestRepository : BaseRepository<VacationRequest>, IVacationRequestRepository
    {
        public VacationRequestRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }
}
