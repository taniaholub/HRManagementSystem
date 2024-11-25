using System;
using System.Collections.Generic;


namespace DAL.Entities
{
    public class Vacancy
    {
        public int IdVacancy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        // Навігаційні властивості
        public ICollection<Application> Applications { get; set; }
    }

}
