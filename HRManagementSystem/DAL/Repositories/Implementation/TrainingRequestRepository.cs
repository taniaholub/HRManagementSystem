using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class TrainingRequestRepository : BaseRepository<TrainingRequest>, ITrainingRequestRepository
    {
        public TrainingRequestRepository(DbContext context) : base(context)
        {
        }
    }
}
