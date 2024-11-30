using DAL.Repositories.Interfaces;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IUserRequestRepository UserRequests { get; }
        IVacancyRepository Vacancies { get; }
        IApplicationRepository Applications { get; }
        void Save();
    }
}
