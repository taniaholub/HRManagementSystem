using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;
using System;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private HRManagementSystemContext db;

        private UserRepository userRepository;
        private VacationRequestRepository vacationRequestRepository;
        private TrainingRequestRepository trainingRequestRepository;
        private UserRequestRepository userRequestRepository;
        private VacancyRepository vacancyRepository;
        private ApplicationRepository applicationRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new HRManagementSystemContext(options);
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IVacationRequestRepository VacationRequests
        {
            get
            {
                if (vacationRequestRepository == null)
                    vacationRequestRepository = new VacationRequestRepository(db);
                return vacationRequestRepository;
            }
        }

        public ITrainingRequestRepository TrainingRequests
        {
            get
            {
                if (trainingRequestRepository == null)
                    trainingRequestRepository = new TrainingRequestRepository(db);
                return trainingRequestRepository;
            }
        }

        public IUserRequestRepository UserRequests
        {
            get
            {
                if (userRequestRepository == null)
                    userRequestRepository = new UserRequestRepository(db);
                return userRequestRepository;
            }
        }

        public IVacancyRepository Vacancies
        {
            get
            {
                if (vacancyRepository == null)
                    vacancyRepository = new VacancyRepository(db);
                return vacancyRepository;
            }
        }

        public IApplicationRepository Applications
        {
            get
            {
                if (applicationRepository == null)
                    applicationRepository = new ApplicationRepository(db);
                return applicationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
