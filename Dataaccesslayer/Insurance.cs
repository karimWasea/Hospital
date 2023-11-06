using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;

namespace Dataaccesslayer
{
    public class Insurance
    {
        public int id { get; set; }
        public string pplicynumber { get; set; }
        public string startdate { get; set; }
        public string Enddate { get; set; }
        public ICollection<Bill> bills { get; set; }

        public IsDeleted IsDeleted { get; set; }


    }
}
