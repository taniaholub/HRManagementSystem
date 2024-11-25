using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories.Implementation
{
    public class VacancyRepository : BaseRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(DbContext context) : base(context)
        {
        }
    }
}
