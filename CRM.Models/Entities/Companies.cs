using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Companies
    {
        public Companies()
        {
            Contacts = new HashSet<Contacts>();
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
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string CompanyType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Zip { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string Fax { get; set; }
        public string AccountNo { get; set; }

        public virtual Site Site { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
    }
}
