using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;
using System;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HRManagementSystemContext _context;

        private UserRepository _userRepository;
        private UserRequestRepository _userRequestRepository;
        private VacancyRepository _vacancyRepository;
        private ApplicationRepository _applicationRepository;

        public EFUnitOfWork(HRManagementSystemContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public IUserRequestRepository UserRequests
        {
            get
            {
                if (_userRequestRepository == null)
                    _userRequestRepository = new UserRequestRepository(_context);
                return _userRequestRepository;
            }
        }

        public IVacancyRepository Vacancies
        {
            get
            {
                if (_vacancyRepository == null)
                    _vacancyRepository = new VacancyRepository(_context);
                return _vacancyRepository;
            }
        }

        public IApplicationRepository Applications
        {
            get
            {
                if (_applicationRepository == null)
                    _applicationRepository = new ApplicationRepository(_context);
                return _applicationRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
