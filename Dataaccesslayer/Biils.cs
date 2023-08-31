using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class Bill
    {
        public IsDeleted IsDeleted { get; set; }

        public int id { get; set; }
        public int Chargedoctor { get; set; }
        public decimal Chargemedicine { get; set; }
        public decimal Roomcharge { get; set; }
        public decimal neringcharge { get; set; }
        public decimal Optioncharge { get; set; }
        public decimal labcharge { get; set; }
        public decimal advanc { get; set; }
        public decimal totalbill { get; set; }
        public int Nofdayes { get; set; }
        public ApplicationUser patient { get; set; }
        public Insurance Insurance { get; set; }
        public string numberbill
        {
            get; set;
        }
    }
}
