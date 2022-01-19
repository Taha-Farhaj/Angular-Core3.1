using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Site
    {
        public Site()
        {
            Companies = new HashSet<Companies>();
            CourierPhoneNos = new HashSet<CourierPhoneNos>();
            Customers = new HashSet<Customers>();
            EmplyeeAppAccess = new HashSet<EmplyeeAppAccess>();
            EstShippingRates = new HashSet<EstShippingRates>();
            Estimation = new HashSet<Estimation>();
            Leads = new HashSet<Leads>();
            SiteSettings = new HashSet<SiteSettings>();
        }

        public long Id { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }
        public string SitePath { get; set; }
        public int? CultureId { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<CourierPhoneNos> CourierPhoneNos { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<EmplyeeAppAccess> EmplyeeAppAccess { get; set; }
        public virtual ICollection<EstShippingRates> EstShippingRates { get; set; }
        public virtual ICollection<Estimation> Estimation { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
        public virtual ICollection<SiteSettings> SiteSettings { get; set; }
    }
}
