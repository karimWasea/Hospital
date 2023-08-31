using Dataaccesslayer;

namespace hospitalVm
{
    using System.ComponentModel.DataAnnotations;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

    public class ContactVm
    {
        public int Id
        { get; set; }
        public int hospitalid         
        { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Hospitalname { get; set; }


    public ContactVm(Contact Contact)
        {
            Id = Contact.id;
            hospitalid = Contact.hospitalid;

            phone = Contact.phone;
            Email = Contact.Email;
        }
        public ContactVm()
        {

        }

        public static Contact CanconvertViewmodel(ContactVm Contact)
        {
            return new Contact
            {
                hospitalid = Contact.hospitalid,
                id = Contact.Id,

                phone = Contact.phone,
            Email = Contact.Email,
        };
        }




    }
}