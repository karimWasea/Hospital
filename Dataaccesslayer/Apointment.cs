using hospitalUtilities.SystemEnums;

using System.ComponentModel.DataAnnotations;

namespace Dataaccesslayer
{
    public class Apointment
    {
        public int id { get; set; }
       
        public DateTime CreateDate { get; set; } 
         
        public string? discreaption { get; set; }
        public AppointmentConfirmation AppointmentConfirmation { get; set; } = AppointmentConfirmation.PendingConfirmation;
        public ICollection<DoctorAppointmentVIsit> DoctorAppointments { get; set; }


    }

 



}