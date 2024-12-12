using DAL.Enums;
using System;

namespace DAL.Entities
{
    public class UserRequest
    {
        public int IdUserRequests { get; set; }
        public int IdUser { get; set; }
        public int? IdVacationRequest { get; set; }
        public int? IdTrainingRequest { get; set; }
        public RequestType RequestType { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
