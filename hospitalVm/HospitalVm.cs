using Dataaccesslayer;

namespace hospitalVm
{
    using System.ComponentModel.DataAnnotations;

    public class HospitalVm
    {
        public int id
        { get; set; }
        public string? Name { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Type { get; set; }
        public string? Pincode { get; set; }


        public static Hospital CanconvertViewmodel(HospitalVm hospital)
        {
            return new Hospital
            {
                id = hospital.id,
                Name = hospital.Name,
                City = hospital.City,
                Pincode = hospital.Pincode,
                Country = hospital.Country,
                Type = hospital.Type,
            };
        }



    }
}