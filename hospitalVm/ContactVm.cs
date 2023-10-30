using Dataaccesslayer;

namespace hospitalVm
{
    using System.ComponentModel.DataAnnotations;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

    public class ContactVm
    {
        [Required(ErrorMessage = "name is required")]

        public int Id
        { get; set; }
        [Required(ErrorMessage ="is rqured")]
        public int hospitalid         
        { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone must contain only numeric characters")]
        public string phone { get; set; }
    
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string ? Hospitalname { get; set; }=string.Empty;


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