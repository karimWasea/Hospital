using Dataaccesslayer;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Net.NetworkInformation;

namespace hospitalVm
{
   
public class PatientVm
    {
       
            public string id { get; set; }
            public string Phonenumber { get; set; }
            public string Title { get; set; }
            public DateTime barthdate { get; set; }
            public IFormFile imgurlupdated { get; set; }
            public Gender Gender { get; set; }

            public string StreetAddress { get; set; }

            public string City { get; set; }

            public RoleRegeseter RoleRegeseter { get; set; }

            public string Nationality { get; set; }
            public string username { get; set; }
            public string Email { get; set; }

            public string imphgurl { get; set; }




            public string PostalCode { get; set; }

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
                Title = ApplicationUser.Title,
              
            };
        }




    }
}