using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Leads = new HashSet<Leads>();
        }

        public long Id { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Password { get; set; }
        public bool? IsLogin { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public long? ContactId { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Site Site { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
    }
}
