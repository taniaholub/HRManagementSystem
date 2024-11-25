using DAL.Enums;
using System;


namespace DAL.Entities
{
    public class Application
    {
        public int IdApplications { get; set; }
        public int IdUser { get; set; }
        public int IdVacancy { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Resume { get; set; }

    }

}
