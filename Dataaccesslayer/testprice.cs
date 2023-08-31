using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class testprice
    {
        public int id { get; set; }
        public Lab lab { get; set; }
        public string testcode { get; set; }
        public decimal tesstprice { get; set; }
        public Bill bill { get; set; }

        public IsDeleted IsDeleted { get; set; }

    }
}
