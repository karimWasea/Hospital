using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    public class prescribmedicine
    {
        public int id { get; set; }
        public Medicine Medicine { get; set; }
        public int Medicineid { get; set; }
        public patientreport Patientreport { get; set; }
        public int Patientreportid { get; set; }

        public IsDeleted IsDeleted { get; set; }


    }
}
