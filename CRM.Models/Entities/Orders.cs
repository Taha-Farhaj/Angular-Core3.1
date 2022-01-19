using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Address = new HashSet<Address>();
            Estimation = new HashSet<Estimation>();
            OrderTransactions = new HashSet<OrderTransactions>();
            SpecSheetAddress = new HashSet<SpecSheetAddress>();
        }

        public long Id { get; set; }
        public decimal Amount { get; set; }
        public bool? IsResaleCertificate { get; set; }
        public string CsrComments { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public long? LeadId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public bool? IsPaymentCompleted { get; set; }

        public virtual Leads Lead { get; set; }
        public virtual RefundOrder RefundOrder { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Estimation> Estimation { get; set; }
        public virtual ICollection<OrderTransactions> OrderTransactions { get; set; }
        public virtual ICollection<SpecSheetAddress> SpecSheetAddress { get; set; }
    }
}
