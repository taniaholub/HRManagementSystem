using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Catalog.DAL.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Навігаційні властивості
        //public ICollection<UserRequest> UserRequests { get; set; }
        //public ICollection<Application> Applications { get; set; }
    }

}
