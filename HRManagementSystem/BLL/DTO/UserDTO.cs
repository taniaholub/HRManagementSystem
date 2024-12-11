using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
