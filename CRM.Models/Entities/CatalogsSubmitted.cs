using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class CatalogsSubmitted
    {
        public long Id { get; set; }
        public long SiteId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string CatalogType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Status { get; set; }
    }
}
