using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Estimation
    {
        public long Id { get; set; }
        public long CustomerProductInfoId { get; set; }
        public int Qty { get; set; }
        public int? Scanning { get; set; }
        public int? Plates { get; set; }
        public int? Stock1 { get; set; }
        public int? Stock2 { get; set; }
        public int? Stock3 { get; set; }
        public int? Printing { get; set; }
        public int? Laminaton { get; set; }
        public int? UvCoating { get; set; }
        public int? BlockMaking { get; set; }
        public int? Foliling { get; set; }
        public int? EmbossingRaiseInk { get; set; }
        public int? DieMaking { get; set; }
        public int? DieCutting { get; set; }
        public int? Pasting { get; set; }
        public int? Binding { get; set; }
        public int? Packing { get; set; }
        public int? FreightLabor { get; set; }
        public int? Misc { get; set; }
        public decimal? CostTotal { get; set; }
        public decimal? VendorProfit { get; set; }
        public int? VendorTotal { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ShippingCost { get; set; }
        public int? AdditionalBills { get; set; }
        public int? OverHead { get; set; }
        public decimal? Profit { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsSelected { get; set; }
        public long? QuoteId { get; set; }
        public long? OrderId { get; set; }
        public long SiteId { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual CustomerProductInfo CustomerProductInfo { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Orders Order { get; set; }
        public virtual QuoteSent Quote { get; set; }
        public virtual Site Site { get; set; }
    }
}
