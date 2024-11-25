using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Data.Entity;


namespace DAL.Repositories.Implementation
{
    public class TrainingRequestRepository : BaseRepository<TrainingRequest>, ITrainingRequestRepository
    {
        public TrainingRequestRepository(DbContext context) : base(context)
        {
        }
    }
}
