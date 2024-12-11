using System;


namespace BLL.DTO
{
    public class UserRequestDTO
    {
        public int IdUserRequests { get; set; }
        public int IdUser { get; set; }
        public string RequestType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
