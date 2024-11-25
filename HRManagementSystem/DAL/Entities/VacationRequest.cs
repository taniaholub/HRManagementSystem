using System;
using System.Collections.Generic;


namespace DAL.Entities
{
    public class VacationRequest
    {
        public int IdVacationRequest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Навігаційні властивості
        public ICollection<UserRequest> UserRequests { get; set; }
    }

}
