using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class Contact
    {
        public IsDeleted IsDeleted { get; set; }

        public int id
        { get; set; }
        public int hospitalid
        { get; set; }
        public Hospital hospital { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }

    }
}
