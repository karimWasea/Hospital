﻿using Dataaccesslayer;

namespace hospitalVm
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class patientreportVm
    {

        

            public int id { get; set; }

            [Required(ErrorMessage = "Diagnosis is required.")]
            public string dignouses { get; set; }

            [Required(ErrorMessage = "Doctor ID is required.")]
            public string doctorid { get; set; }

            [Required(ErrorMessage = "Patient ID is required.")]
            public string patientid { get; set; }

            [Required(ErrorMessage = "Doctor name is required.")]
            public string doctorname { get; set; }

            [Required(ErrorMessage = "Patient name is required.")]
            public string patientName { get; set; }

            [Required(ErrorMessage = "Report date is required.")]
            public DateTime Reportdate { get; set; }

            [Required(ErrorMessage = "Doctor Appointment Visit ID is required.")]
            public int DoctorAppointmentVIsitid { get; set; }

            [Required(ErrorMessage = "Patient Report Medicine ID is required.")]
            public int patientreporMedicinetid { get; set; }

            [Required(ErrorMessage = "Medicine ID is required.")]
            public int Medicineid { get; set; }

            [Required(ErrorMessage = "IsDeleted is required.")]
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