using Dataaccesslayer;

using hospitalUtilities.SystemEnums;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.ComponentModel.DataAnnotations;

namespace hospitalVm
{
 
public class ApointmentVm
    {
        public int id
        { get; set; }
        public int DoctorAppointmentVIsitid
        { get; set; }

        public string ApplicationUserid { get; set; }
        public DateTime CreateDate { get; set; }
        public string Duration { get; set; }
        public bool IsAvailable { get; set; } = false;
        public string discreaption { get; set; }


        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string doctorid { get; set; }
        public AppointmentConfirmation AppointmentConfirmation { get; set; }
        public VisitType VisitType { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public string patientid { get; set; }
        public string doctosspilist { get; set; }
        public IsDeleted isdeleted { get; set; }
        public string VisiteNotebydoctor { get; set; }


        public static Apointment CanconvertViewmodel(ApointmentVm model)
        {
            return new Apointment
            {

              //  applicationUserid = model.applicationUserid,
                id = model.id,
                CreateDate = model.CreateDate,
                discreaption = model.discreaption,
                //isavilable = model.isavilable,
                //Duration = model.Duration,
            

            };
        }

        public static DoctorAppointmentVIsit CanconvertViewmodeldoctorvisite(ApointmentVm model)
        {
            return new DoctorAppointmentVIsit
            {

                Id =model.DoctorAppointmentVIsitid,
                DoctorId =model.doctorid,
                patientid =model.patientid,
                visitStatus =model.VisitStatus,
                VisiteNotebydoctor=model.VisiteNotebydoctor,
                VisitType =model.VisitType,
                AppointmentId =model.id,
                IsDeleted =model.isdeleted,


            };
        }




    }
}