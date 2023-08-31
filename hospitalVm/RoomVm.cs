using Dataaccesslayer;

using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace hospitalVm
{
    public class RoomVm
    {



        public int id
        { get; set; }
        public int hospitalid
        { get; set; }
        public string RoomName { get; set; }
        public string Stuts { get; set; }
        public string hospitalname { get; set; }
        public string type { get; set; }



        public static Room CanconvertViewmodel(RoomVm Room)
        {
            return new Room
            { hospitalid=Room.hospitalid,
                type=Room.type,
            RoomName=Room.RoomName,
            Stuts=Room.Stuts,
            id=Room.id,
            

            };
        }



       

    }
}