using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BWC.Models.Entities
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
       
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


    }
}
