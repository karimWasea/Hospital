using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class Department
    {
        public IsDeleted IsDeleted { get; set; }

        public int id { get; set; }
        public int? Hospitalid { get; set; }
        public ICollection<ApplicationUser> Employee { get; set; }
        public string? Name { get; set; }
        public string? discraption { get; set; }

         public Hospital Hospital { get; set; }

       
    }

}
