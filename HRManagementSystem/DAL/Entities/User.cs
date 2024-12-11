using DAL.Enums;
using System.Collections.Generic;


namespace DAL.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public List<Role> Roles { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<UserRequest> UserRequests { get; set; }
    }

}