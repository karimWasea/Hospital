using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {
        public bool Rols { get; set; }
        // other properties and methods
    }

    public class ApplicationUser : IdentityUser
    {
        // public string id { get; set; }
       // [NotMapped]
        public List<DoctorAppointmentVIsit> DoctorAppointments { get; set; }
        public IsDeleted IsDeleted { get; set; }
        public ICollection<PatientHistory> Histories { get; set; }

        public string Title { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiringDate { get; set; }

        public string Contracturl { get; set; }
        public int WorkingDaysinWeek { get; set; }

        public virtual ICollection<DoctorTimingShift> DoctorTimingShifts { get; set; }
        public virtual ICollection<DoctorDaywork> DoctorDayworks { get; set; }

        [Required]
        public Gender Gender { get; set; }
        [Required]

        public string StreetAddress { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public RoleRegeseter RoleRegeseter { get; set; }
        [Required]

        public string Nationality { get; set; }
        [Required]

        public string imphgurl { get; set; }
        [Required]

        public spicialist spicialist { get; set; }
        [Required]
        public Cofimationdoctor statusDoctorInSystem { get; set; } 

        [Required]
        public string PostalCode { get; set; }
        [NotMapped]
//public ICollection<Apointment> apointments { get; set; }
        //[NotMapped]

        public ICollection<Lab> labs { get; set; }
        [NotMapped]
        public ICollection<payroll> payroll { get; set; }
        [NotMapped]
        public List<TimingShifts> Timings { get; set; }

        [Required]

        public DateTime Dateofbarth { get; set; }


    }

   


}
