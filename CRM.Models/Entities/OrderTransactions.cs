using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class OrderTransactions
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public string CreditCardType { get; set; }
        public string AdditionalNotes { get; set; }
        public bool SendApprovalEmailPriorToPrinting { get; set; }
        public string ProcessorData { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public decimal? ConversionRate { get; set; }
        public string Comments { get; set; }
        public decimal? RefundAmount { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Orders Order { get; set; }
    }
}
