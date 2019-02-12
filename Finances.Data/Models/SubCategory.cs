using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class SubCategory
    {
        public long IdSubCategory { get; set; }
        public string DsSubCategory { get; set; }
        public long IdCategory { get; set; }
        public Category Category { get; set; }
    }
}
