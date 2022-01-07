using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWC.Models.ViewModel
{
    public class UserList
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
