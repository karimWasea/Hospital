using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    public class Medicine
    {
        public int Id
        { get; set; }
        public IsDeleted IsDeleted { get; set; }

        public ICollection<MedicineReport> medicineReports { get; set; }
        public ICollection<prescribmedicine> prescribmedicines { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string discreaption { get; set; }
        public decimal Coust { get; set; }
        public DateTime prouductiondate { get; set; }
        public DateTime expireddate { get; set; }


    }
}
