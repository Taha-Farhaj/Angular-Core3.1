using CRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.Entities.User
{
    public class Roles : BaseEntity
    {
        public long RoleId { get; set; }
        public string Name { get; set; }

    }
}
