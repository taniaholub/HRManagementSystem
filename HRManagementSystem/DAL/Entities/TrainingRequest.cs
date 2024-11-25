using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class TrainingRequest
    {
        public int IdTrainingRequest { get; set; }
        public string TrainingName { get; set; }
        public string Justification { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Навігаційні властивості
        public ICollection<UserRequest> UserRequests { get; set; }
    }

}
