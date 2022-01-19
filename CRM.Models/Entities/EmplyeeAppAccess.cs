using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class EmplyeeAppAccess
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Site Site { get; set; }
    }
}
