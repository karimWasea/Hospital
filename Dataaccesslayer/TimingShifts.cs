using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    public class TimingShifts 
    {
        public int id { get; set; }
        public DateTime ? startshift { get; set; }
        public DateTime ? Endsifit { get; set; }
      
        public double?  Duration { get; set; }
        public Stutus Stutus { get; set; }

        public IsDeleted IsDeleted { get; set; }

        public virtual ICollection<DoctorTimingShift> DoctorTimingShifts { get; set; }

    }










  
   

}
