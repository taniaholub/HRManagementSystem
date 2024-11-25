using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementation
{
    public class VacancyRepository : BaseRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }
}
