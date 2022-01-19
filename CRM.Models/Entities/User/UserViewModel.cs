using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models.Entities
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        //public int OfficeId { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}
