using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Setting
    {
        public Setting()
        {
            SiteSettings = new HashSet<SiteSettings>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual ICollection<SiteSettings> SiteSettings { get; set; }
    }
}
