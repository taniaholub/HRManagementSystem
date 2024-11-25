﻿using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.EF;

namespace DAL.Repositories.Implementation
{
    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(HRManagementSystemContext context) : base(context)
        {
        }
    }
}