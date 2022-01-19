using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Leads
    {
        public Leads()
        {
            CustomerProductInfo = new HashSet<CustomerProductInfo>();
            LeadProcess = new HashSet<LeadProcess>();
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string LeadName { get; set; }
        public string Status { get; set; }
        public bool? AvailableToEveryone { get; set; }
        public string Comment { get; set; }
        public string Probability { get; set; }
        public bool IsRepeatOrder { get; set; }
        public bool IsRepeatCustomer { get; set; }
        public bool IsRepeatLead { get; set; }
        public int LeadType { get; set; }
        public long? VisitorId { get; set; }
        public long? CompanyId { get; set; }
        public long? CustomerId { get; set; }
        public bool? IsPartialPayment { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? PartialPaymentPercentage { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Site Site { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual ICollection<CustomerProductInfo> CustomerProductInfo { get; set; }
        public virtual ICollection<LeadProcess> LeadProcess { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
