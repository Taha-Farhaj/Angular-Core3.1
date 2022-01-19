using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class TrackingIntimation
    {
        public long Id { get; set; }
        public string TrackingNo { get; set; }
        public string CourierInfo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string NoOfCartons { get; set; }
        public string PieceNo { get; set; }
        public long OrderId { get; set; }
        public string Schedule { get; set; }
        public string IntimationType { get; set; }
        public string Mode { get; set; }
        public string Week { get; set; }
    }
}
