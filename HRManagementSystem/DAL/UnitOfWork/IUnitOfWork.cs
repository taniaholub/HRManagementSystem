using DAL.Repositories.Interfaces;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVacationRequestRepository VacationRequests { get; }
        ITrainingRequestRepository TrainingRequests { get; }
        IUserRequestRepository UserRequests { get; }
        IVacancyRepository Vacancies { get; }
        IApplicationRepository Applications { get; }

        void Save();
    }
}
