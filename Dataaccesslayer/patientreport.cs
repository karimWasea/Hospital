using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    public class patientreport
    {
        public int id { get; set; }
        public string dignouses { get; set; }
        public ApplicationUser doctor { get; set; }
        public string doctorid { get; set; }
        public ApplicationUser patient { get; set; }
        public string patientid { get; set; }
        public int DoctorAppointmentVIsitid { get; set; }
        public DoctorAppointmentVIsit  DoctorAppointmentVIsit { get; set; }
        public ICollection<prescribmedicine> Prescribmedicines { get; set; }
        public IsDeleted IsDeleted { get; set; }



    }
}
