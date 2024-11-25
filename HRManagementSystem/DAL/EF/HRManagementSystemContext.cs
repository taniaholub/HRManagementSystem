﻿using Microsoft.EntityFrameworkCore;
using DAL.Entities;


namespace DAL.EF
{
    public class HRManagementSystemContext : DbContext
    {
        // Набори сутностей (таблиці в базі даних)
        public DbSet<User> Users { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<TrainingRequest> TrainingRequests { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Application> Applications { get; set; }

        // Конструктор для передачі налаштувань
        public HRManagementSystemContext(DbContextOptions<HRManagementSystemContext> options)
            : base(options)
        {
        }
    }
}