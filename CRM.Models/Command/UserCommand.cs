using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.Command
{
    public class UserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? SiteId { get; set; }
        public PagingData PagingData { get; set; }
        public string Email { get; set; }
    }
}
