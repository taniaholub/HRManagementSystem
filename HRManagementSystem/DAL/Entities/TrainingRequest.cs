using DAL.Enums;
using System;

namespace DAL.Entities
{
    public class TrainingRequest
    {
        public int IdTrainingRequest { get; set; }
        public string TrainingName { get; set; }
        public string Justification { get; set; }
        public string Reason { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

}
