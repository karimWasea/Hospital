using Dataaccesslayer;

namespace hospitalVm
{
    using System.ComponentModel.DataAnnotations;

    public class HospitalVm
    {

        public int id
        { get; set; } = 0;
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be a 6-digit number")]
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