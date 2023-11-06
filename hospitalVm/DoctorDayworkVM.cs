using Dataaccesslayer;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace hospitalVm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using hospitalUtilities.SystemEnums;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;

    public class DoctorDayworkVM
    {

            public Task<ApplicationUser?> n;

            public IEnumerable<SelectListItem> GetDoctors { get; set; }


            public int DoctorDayworkId { get; set; }

            public string DoctorId { get; set; }
            public string? DoctorName { get; set; }
            public string? dayname { get; set; }
            [Required]
            public int WeekDaystId { get; set; }
            public string StratingAmShafit { get; set; }
            public string StartingPmShift { get; set; }
            public string WEAkSiifts { get; set; }
            public SHifts Hifts { get; set; }
            //  public FormalStartingShift? FormalStartingShift { get; set; }
            //  public FormalEndingShift? FormalEndingShift { get; set; }
            [Required]
            public Boolean isam { get; set; }
            [Required]
            public Boolean ispm { get; set; }
            public Boolean ischekedday { get; set; }
   
    //public DoctorDayworkVM(DoctorDaywork Contact)
    //{

            //}
            //public DoctorDayworkVM()
            //{

            //}

    public static DoctorDaywork CanconvertViewmodel(DoctorDayworkVM Contact)
        {
            return new DoctorDaywork
            {
                //ChoseAmShift=Contact.isFormalStartingShift,
                //ChosePmSHift=Contact.isFormalStartingShift,

                WeekDaystId = (int)Contact.WeekDaystId,
                DoctorId = Contact.DoctorId,
                DoctorDayworkId = Contact.DoctorDayworkId,
                FormalStartingShift = Contact.Hifts,
                 
            };
        }






    }
}