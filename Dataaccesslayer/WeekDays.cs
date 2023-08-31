using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
  public   class WeekDays
    { 

        public int  WeekDaysId { get; set; } 
        public string WeekDaysName { get; set; }
        public string  StratingAmShafit { get; set; }
        public string StartingPmShift { get; set; }

        public virtual ICollection<DoctorDaywork> DoctorDayworks { get; set; }
        public IsDeleted IsDeleted { get; set; }

    }

}
