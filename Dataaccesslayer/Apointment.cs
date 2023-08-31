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

    public enum AppointmentConfirmation
    {
        [Display(Name = "Pending Confirmation")]
        PendingConfirmation = 0,

        [Display(Name = "Confirmed by Doctor")]
        ConfirmedByDoctor = 1,

        [Display(Name = "Cancelled by Doctor")]
        CancelledByDoctor = 2,

        [Display(Name = "Cancelled by Patient")]
        CancelledByPatient = 3,
    }



}