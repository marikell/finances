using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class Category
    {
        public Int32 IdCategory { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
        public string Id { get; set; }
        public virtual Account Account { get; set; }
    }
}
