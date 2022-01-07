using System;
using System.Collections.Generic;
using System.Text;

namespace BWC.Models.Command
{
    public class FilesCommand
    {
        public long TransferId { get; set; }
        public string FileType { get; set; }
    }
}
