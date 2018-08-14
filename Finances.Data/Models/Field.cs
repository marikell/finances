using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class Field
    {
        public Int32 IdField { get; set; }
        public string Description { get; set; }
        public Int32 IdCategory { get; set; }
        public virtual Category Category { get; set; }
    }
}
