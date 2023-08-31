using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccesslayer
{
    public class Room
    {
        public int id
        { get; set; }
        public int hospitalid
        { get; set; }
        public Hospital hospital { get; set; }
        public string RoomName { get; set; }
        public string Stuts { get; set; }
        public string type { get; set; }
        public IsDeleted IsDeleted { get; set; }


    }
}
