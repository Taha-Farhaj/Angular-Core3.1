using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Address
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int? QuantityForShipping { get; set; }
        public string Email { get; set; }
        public string Ccemail { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ContactId { get; set; }
        public bool? IsBillingAddress { get; set; }
        public long? OrderId { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Orders Order { get; set; }
    }
}
