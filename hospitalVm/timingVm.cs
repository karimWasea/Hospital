using Dataaccesslayer;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.ComponentModel.DataAnnotations;

namespace hospitalVm
{

    public class timingshiftVm
    {





        public int id { get; set; }
        [Required(ErrorMessage = "  is required.")]

        public string applicatinUserdictorid { get; set; }
        public DateTime? startshift { get; set; }
        [Required(ErrorMessage = "Endsifit is required.")]

        public DateTime? Endsifit { get; set; }
        

        public double Duration { get; set; }
        public string doctorName { get; set; }=string.Empty;
        [EnumDataType(typeof(Stutus))]

        [Required(ErrorMessage = "Status is required.")]

        public Stutus Stutus
        {
            get; set;
        }




    public static TimingShifts CanconvertViewmodel(timingshiftVm model)
        {
            return new TimingShifts
            {
                
                // MorningSifttimEndtimeAM=model.MorningSifttimEndtimeAM,
                //MorningSifttimStarttimeAM = model.MorningSifttimStarttimeAM, 
                Duration=model.Duration,
                 id=model.id,
                 startshift=model.startshift,
                 Endsifit=model.Endsifit,
                // DoctorId   = model.applicatinUserdictorid,
                 //AfternoonShiffttimStarttimePM=model.AfternoonShiffttimStarttimePM,
                 //AftornoonShiftfttimEndtimePM=model.AftornoonShiftfttimEndtimePM,
                 Stutus=model.Stutus,
                  
            

            };
        }



       

    }
}