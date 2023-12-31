﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    public class DoctorAppointmentVIsit
    {
        public int  Id { get; set; }
        public string ? DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }


        public int AppointmentId { get; set; }
        public Apointment Appointment { get; set; }
        public ApplicationUser patient { get; set; }
        public string? patientid { get; set; }
        public string? VisiteNotebydoctor { get; set; }
        public DateTime? VisiteDate { get; set; } 
        public VisitType VisitType { get; set; } 
        public VisitStatus  visitStatus { get; set; } 
        public IsDeleted IsDeleted { get; set; } 


    }



}
