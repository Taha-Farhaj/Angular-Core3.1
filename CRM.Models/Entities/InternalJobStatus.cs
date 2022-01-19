using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class InternalJobStatus
    {
        public InternalJobStatus()
        {
            InternalJob = new HashSet<InternalJob>();
            InternalJobStatusValues = new HashSet<InternalJobStatusValues>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<InternalJob> InternalJob { get; set; }
        public virtual ICollection<InternalJobStatusValues> InternalJobStatusValues { get; set; }
    }
}
