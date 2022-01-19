using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class CourierPhoneNos
    {
        public int Id { get; set; }
        public string CourierName { get; set; }
        public string PhoneNo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? SiteId { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Site Site { get; set; }
    }
}
