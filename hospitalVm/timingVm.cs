using Dataaccesslayer;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.ComponentModel.DataAnnotations;

namespace hospitalVm
{

    public class timingshiftVm
    {





        public int id { get; set; }
        public string applicatinUserdictorid { get; set; }
        public DateTime? startshift { get; set; } =
        DateTime.Now;
        public DateTime? Endsifit { get; set; }
        //= new DateTime(2023, 8, 8, 8, 0, 0);  // Initialize with a specific date and time
        //public TwelveHourClockAm MorningSifttimStarttimeAM { get; set; }
        //public TwelveHourClockAm MorningSifttimEndtimeAM { get; set; }
        //public TwelveHourClockPm AfternoonShiffttimStarttimePM { get; set; }
        //public TwelveHourClockPm AftornoonShiftfttimEndtimePM { get; set; }
        public double Duration { get; set; }
        public string doctorName { get; set; }
        //   [UIHint("InlineDropdown")]


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