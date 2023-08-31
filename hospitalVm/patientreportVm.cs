using Dataaccesslayer;

namespace hospitalVm
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class patientreportVm
    {
       
            public int id { get; set; }
            public string dignouses { get; set; }
            public string doctorid { get; set; }
            public string patientid { get; set; }
            public string doctorname { get; set; }
            public string patientName { get; set; }
            public DateTime Reportdate { get; set; }
            public int DoctorAppointmentVIsitid { get; set; }

            public int patientreporMedicinetid { get; set; }
            public int Medicineid { get; set; }
            public IsDeleted IsDeleted { get; set; }




            public static patientreport CanconvertViewmodel(patientreportVm Room)
        {
            return new patientreport
            {

                DoctorAppointmentVIsitid = Room.DoctorAppointmentVIsitid,
                 id = Room.id,
                  dignouses= Room.dignouses,
              patientid = Room.patientid,
              doctorid= Room.doctorid,
               

            };
        }



       

    }
}