using Dataaccesslayer;

using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace hospitalVm
{
    public class RoomVm
    {


 
        public int id
        { get; set; }
        [Required(ErrorMessage = "Email is required")]

        public int hospitalid
        { get; set; }
        [Required(ErrorMessage = "RoomName is required")]

        public string RoomName { get; set; }
        [Required(ErrorMessage = "Stuts is required")]

        public string Stuts { get; set; }
        public string hospitalname { get; set; }= string.Empty;
        [Required(ErrorMessage = "type is required")]

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