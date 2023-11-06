using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;


namespace Dataaccesslayer
{
    public class payroll
    {

        public IsDeleted IsDeleted { get; set; }


        public int Id
        { get; set; }
        public decimal salary { get; set; }
        public decimal Netsalary { get; set; }
        public decimal hoursalary { get; set; }
        public decimal bonassalary { get; set; }
        public decimal compensalation { get; set; }

        public ApplicationUser EmployeId { get; set; } // Assuming room collection contains room numbers or names

        public string Accountantnumber { get; set; }
    }
}
