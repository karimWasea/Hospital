using Dataaccesslayer;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Net.NetworkInformation;
using hospitalUtilities;

namespace hospitalVm
{
   
public class PatientVm
    {
        public string id { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string Phonenumber { get; set; }


        [Display(Name = "Working Days in Week")]
        public int WorkingDaysinWeek { get; set; }

     

        [Display(Name = "Image File")]
        [CustomImageValidation]

        public IFormFile imgurlupdated { get; set; }
        [Required(ErrorMessage = "Role is required")]

        [EnumDataType(typeof(Gender))]

        public Gender Gender { get; set; }

        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "City is required")]

        public string City { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [EnumDataType(typeof(RoleRegeseter))]
        [Display(Name = "Role")]

        public RoleRegeseter RoleRegeseter { get; set; }
        [Required(ErrorMessage = "Username is required")]

        public string Nationality { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Profile Image")]
        public string imphgurl { get; set; } = string.Empty;

        [Display(Name = "Specialist")]
        [Required(ErrorMessage = "Role is required")]
        [EnumDataType(typeof(spicialist))]
        public spicialist spicialist { get; set; }

        [Display(Name = "Status in System")]
        [Required(ErrorMessage = "  is required")]
        [EnumDataType(typeof(Cofimationdoctor))]
        public Cofimationdoctor StatusDoctorInSystem { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dateofbarth { get; set; }
      




         









            public static ApplicationUser CanconvertViewmodel(PatientVm ApplicationUser)
        {
            return new ApplicationUser
            {
                Id = ApplicationUser.id,
                UserName = ApplicationUser.username,

                Email = ApplicationUser.Email,
                RoleRegeseter = ApplicationUser.RoleRegeseter,
                Gender = ApplicationUser.Gender,
                StreetAddress = ApplicationUser.StreetAddress,
                City = ApplicationUser.City,
                Dateofbarth = ApplicationUser.Dateofbarth,
                PhoneNumber = ApplicationUser.Phonenumber,
                Nationality = ApplicationUser.Nationality,
                imphgurl = ApplicationUser.imphgurl,
                PostalCode = ApplicationUser.PostalCode,

              
            };
        }




    }
}