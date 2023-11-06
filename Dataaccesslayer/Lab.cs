using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;

namespace Dataaccesslayer
{
    public class Lab
    {
        public IsDeleted IsDeleted { get; set; }

        public int id { get; set; }
        public int hight { get; set; }
        public int wight { get; set; }
        public int bloodpressur { get; set; }
        public int temprature { get; set; }
        public string labnumber { get; set; }
        public string testtype { get; set; }
        public string testcode { get; set; }
        public string testresult { get; set; }
        public ApplicationUser patient { get; set; }
        public string patientid { get; set; }



    }
}
