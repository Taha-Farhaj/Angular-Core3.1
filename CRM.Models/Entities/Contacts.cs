using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Contacts
    {
        public Contacts()
        {
            AddressNavigation = new HashSet<Address>();
            Customers = new HashSet<Customers>();
            PromotionEmail = new HashSet<PromotionEmail>();
            SpecSheetAddress = new HashSet<SpecSheetAddress>();
        }

        public long Id { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ContactName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public DateTime? Birthday { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PhoneType { get; set; }
        public string Email { get; set; }
        public string SecondaryEmail { get; set; }
        public string EmailType { get; set; }
        public string Website { get; set; }
        public string WebsiteType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Zip { get; set; }
        public string Details { get; set; }
        public string ContactType { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Utmsource { get; set; }
        public string Utmmedium { get; set; }
        public string Utmcampaign { get; set; }
        public string Utmcontent { get; set; }
        public string Utmterm { get; set; }
        public string Conditions { get; set; }
        public long? CompanyId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual ICollection<Address> AddressNavigation { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<PromotionEmail> PromotionEmail { get; set; }
        public virtual ICollection<SpecSheetAddress> SpecSheetAddress { get; set; }
    }
}
