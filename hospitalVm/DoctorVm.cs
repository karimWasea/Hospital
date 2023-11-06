using Dataaccesslayer;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System;

using Microsoft.AspNetCore.Mvc;
using hospitalUtilities;
using hospitalUtilities.SystemEnums;

namespace hospitalVm
{
    public class DoctorVm
    {
        public string id { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Phone Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and be at least 8 characters long.")]
        public string PassWord { get; set; }

        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative value")]
        public decimal Salary { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

        //[Display(Name = "Bonus Working Hours")]
        //public int BonusWorkingHours { get; set; }

        [Display(Name = "Contract URL")]
        public string Contracturl { get; set; } = string.Empty;


        [Display(Name = "Image Contracturluplod")]
        [CustomImageValidation]

        public IFormFile Contracturluplod { get; set; }

        [Display(Name = "Working Days in Week")]
        public int WorkingDaysinWeek { get; set; }

        [Display(Name = "Starting Shift")]
        public string StartingShift { get; set; } = string.Empty;

        [Display(Name = "Ending Shift")]
        public string EndingShift { get; set; } = string.Empty;

        [Display(Name = "Image File")]
        [ CustomImageValidation]

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
    



    //public ApplicationuserVm(ApplicationUser ApplicationUser)
    //{
    //    id = ApplicationUser.Id;
    //    username = ApplicationUser.UserName;
    //    Email = ApplicationUser.Email;
    //    RoleRegeseter = ApplicationUser.RoleRegeseter;
    //    Gender = ApplicationUser.Gender;
    //    StreetAddress = ApplicationUser.StreetAddress;
    //    City = ApplicationUser.City;
    //    Dateofbarth= ApplicationUser.Dateofbarth;
    //    Phonenumber = ApplicationUser.PhoneNumber;
    //    Nationality = ApplicationUser.Nationality;
    //    imphgurl = ApplicationUser.imphgurl;
    //    PostalCode= ApplicationUser.PostalCode;


    //}
    //public ApplicationuserVm()
    //{

    //}

    public static ApplicationUser CanconvertViewmodel(DoctorVm ApplicationUser)
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
                Title = ApplicationUser.Title,
                HiringDate = ApplicationUser.HiringDate,
                Contracturl = ApplicationUser.Contracturl,
                statusDoctorInSystem = ApplicationUser.StatusDoctorInSystem,
                 WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                Salary = ApplicationUser.Salary,
                 PasswordHash= ApplicationUser.PassWord,
            };
        }




    }
}