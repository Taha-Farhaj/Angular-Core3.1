using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BWC.WebApi.Models
{
    public class PasswordResetCommand
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
