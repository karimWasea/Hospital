using Dataaccesslayer;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using hospitalUtilities.SystemEnums;

namespace hospitalVm
{
  
public class ApplicationuserVm
    {
        public string id { get; set; }
        public string Phonenumber { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiringDate { get; set; }
        public int BonusWorkingHours { get; set; }
        public string Contracturl { get; set; }
        public int WorkingDays { get; set; }
        public string StartingShift { get; set; }
        public string EndingShift { get; set; }

        public Gender Gender { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public RoleRegeseter RoleRegeseter { get; set; }

        public string Nationality { get; set; }
        public string username { get; set; }
        public string Email { get; set; }

        public string imphgurl { get; set; }

        public spicialist spicialist { get; set; }
        public Cofimationdoctor StatusDoctorInSystem { get; set; }

      
        public string PostalCode { get; set; }
   
      

    

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

        public static ApplicationUser CanconvertViewmodel(ApplicationuserVm ApplicationUser)
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
              //  Title = ApplicationUser.Title,
              //  HiringDate=ApplicationUser.HiringDate,
              //  Contracturl= ApplicationUser.Contracturl,
              //BonusWorkingHours = ApplicationUser.BonusWorkingHours,
              //statusDoctorInSystem= ApplicationUser.StatusDoctorInSystem,
              //StartingShift=ApplicationUser.StartingShift,
              //EndingShift=ApplicationUser.EndingShift,  
              //WorkingDays=ApplicationUser.WorkingDays,
              //Salary=ApplicationUser.Salary,
              






            };
        }




    }
}