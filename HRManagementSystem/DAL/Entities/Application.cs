using DAL.Entities;
using System;


namespace DAL.Entities
{
    public class Application
    {
        public int IdApplications { get; set; }
        public int IdUser { get; set; }
        public int IdVacancy { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Resume { get; set; }

        // Навігаційні властивості
        public User User { get; set; }
        public Vacancy Vacancy { get; set; }
    }

}
