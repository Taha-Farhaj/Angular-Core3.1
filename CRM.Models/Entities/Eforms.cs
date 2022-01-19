using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Eforms
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public long CustomerProductInfoId { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string EformNo { get; set; }
        public decimal? AdvancePayment { get; set; }
        public DateTime? AdvancePaymentDate { get; set; }
    }
}
