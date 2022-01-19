using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class InternalJob
    {
        public long Id { get; set; }
        public long? CustomerProductInfoId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? TargetDeliveryDate { get; set; }
        public byte? StatusId { get; set; }
        public byte? StatusProcessId { get; set; }
        public byte? InternalJobStatus { get; set; }
        public bool? IsPartialShipping { get; set; }
        public string PartialQty { get; set; }
        public string PrintingMachine { get; set; }
        public DateTime? Ptd { get; set; }
        public DateTime? PressFwdDate { get; set; }
        public DateTime? ProductionCompleteDate { get; set; }
        public DateTime? ShipppingStartDate { get; set; }
        public DateTime? ShipppingCompleteDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual CustomerProductInfo CustomerProductInfo { get; set; }
        public virtual InternalJobStatusValues InternalJobStatusNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual InternalJobStatus Status { get; set; }
        public virtual InternalJobStatusValues StatusProcess { get; set; }
    }
}
