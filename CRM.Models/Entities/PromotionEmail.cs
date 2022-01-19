using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class PromotionEmail
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long ProductId { get; set; }
        public string TimeFrame { get; set; }
        public int NewOrder { get; set; }
        public int ReOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
    }
}
