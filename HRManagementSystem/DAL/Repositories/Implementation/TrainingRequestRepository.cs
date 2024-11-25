using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementation
{
    public class TrainingRequestRepository : BaseRepository<TrainingRequest>, ITrainingRequestRepository
    {
        public TrainingRequestRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }
}
