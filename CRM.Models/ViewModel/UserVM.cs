using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.ViewModel
{
    public class UserVM
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Deaprtment { get; set; }
        public string Position { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
