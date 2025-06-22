using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.core.Entities
{
    public class Site : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
