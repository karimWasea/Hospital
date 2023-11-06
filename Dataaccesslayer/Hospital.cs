using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hospitalUtilities.SystemEnums;

namespace Dataaccesslayer
{
    public class Hospital
    {

        // Properties
        public int id
        { get; set; }
        public IsDeleted IsDeleted { get; set; }

        public string ? Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Department>  departments { get; set; }
        public ICollection<Contact> Contacts { get; set; } // Assuming room collection contains room numbers or names
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Type { get; set; }
        public string ?Pincode { get; set; }

    }

}
