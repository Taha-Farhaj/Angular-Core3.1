using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class QuoteSent
    {
        public QuoteSent()
        {
            Estimation = new HashSet<Estimation>();
        }

        public long Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UploadFile { get; set; }
        public string AdditionalComments { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string PaymentTerms { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual ICollection<Estimation> Estimation { get; set; }
    }
}
