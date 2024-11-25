using DAL.Enums;
using System;


namespace DAL.Entities
{
    public class Vacancy
    {
        public int IdVacancy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }

    }

}
