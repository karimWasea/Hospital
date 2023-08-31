using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dataaccesslayer
{
    public class DoctorDaywork
    {
        public IsDeleted IsDeleted { get; set; }

        public int DoctorDayworkId { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual ApplicationUser Doctor { get; set; }

        [ForeignKey("WeekDays")]
        public int WeekDaystId { get; set; }
        public virtual WeekDays WeekDays { get; set; }

        public SHifts FormalStartingShift { get; set; } = SHifts.HasNosifits;
    }

    //public enum StartShift
    //{


    //    [Display(Name = "8 AM")]
    //    EightpM= 8,

    //}

    public enum SHifts
    {
       
        
        morinimgSiftfrrom8Amto5pm, 
       nightSiftfrrom5pmto8Am
,HasNosifits

    }







}
