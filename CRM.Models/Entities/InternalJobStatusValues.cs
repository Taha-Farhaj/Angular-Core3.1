using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class InternalJobStatusValues
    {
        public InternalJobStatusValues()
        {
            InternalJobInternalJobStatusNavigation = new HashSet<InternalJob>();
            InternalJobStatusProcess = new HashSet<InternalJob>();
        }

        public byte Id { get; set; }
        public byte InternalJobStatusId { get; set; }
        public string Value { get; set; }
        public int SortOrder { get; set; }

        public virtual InternalJobStatus InternalJobStatus { get; set; }
        public virtual ICollection<InternalJob> InternalJobInternalJobStatusNavigation { get; set; }
        public virtual ICollection<InternalJob> InternalJobStatusProcess { get; set; }
    }
}
