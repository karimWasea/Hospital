using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class DoctorTimingShift
    {
        public int DoctorTimingShiftId { get; set; }

        public string DoctorId { get; set; }
        public virtual ApplicationUser Doctor { get; set; }

        public int TimingShiftId { get; set; }
        public virtual TimingShifts TimingShift { get; set; }
        public IsDeleted IsDeleted { get; set; }

    }

}
