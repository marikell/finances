using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Models
{
    public class Account: IdentityUser
    {
        public DateTime DatStart { get; set; }
        public DateTime DatEnd { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
