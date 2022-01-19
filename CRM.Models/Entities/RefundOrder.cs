﻿using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class RefundOrder
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public decimal RefundAmount { get; set; }
        public string Comments { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Orders IdNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
    }
}
