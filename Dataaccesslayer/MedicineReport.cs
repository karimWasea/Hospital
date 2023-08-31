using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class MedicineReport
    {
        public int Id
        { get; set; }
        public Medicine medicine { get; set; }
        public IsDeleted IsDeleted { get; set; }

        public suplier suplier { get; set; }
        public string company { get; set; }
        public string Country { get; set; }
        public string Quantity { get; set; }
        public DateTime prouductiondate { get; set; }
        public DateTime expireddate { get; set; }


    }
}
