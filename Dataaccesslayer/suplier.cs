using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class suplier
    {
        public int id
        { get; set; }

        public string company { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public ICollection<MedicineReport> medicines { get; set; }
        public IsDeleted IsDeleted { get; set; }


    }
}