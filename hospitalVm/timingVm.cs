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
        [Required(ErrorMessage = "Status is required.")]


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
                

                Duration=model.Duration,
                 id=model.id,
                 startshift=model.startshift,
                 Endsifit=model.Endsifit,
       
                 Stutus=model.Stutus,
                  
            

            };
        }



       

    }
}