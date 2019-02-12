using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class Category
    {
        public long IdCategory { get; set; }
        public string DsCategory { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
