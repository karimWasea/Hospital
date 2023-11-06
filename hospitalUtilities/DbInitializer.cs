using Dataaccesslayer;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace hospitalUtilities
{
    public class DbInitializers : IDbInitializer
    {


        private readonly UserManager<ApplicationUser> _usermanger;
        private readonly RoleManager<IdentityRole> _Rolemanger;
        private readonly ApplicationDBcontext _context;

        public DbInitializers(UserManager<ApplicationUser> usermanger, RoleManager<IdentityRole> rolemanger, ApplicationDBcontext context)
        {
            _usermanger = usermanger;
            _Rolemanger = rolemanger;
            _context = context;
        }

        public void Initialize()
        {



            try
            {
                
                    
                
                
                
                
                
                
                 if (_context.Database.GetAppliedMigrations().Count() > 0)

                    _context.Database.Migrate();


            }
            catch (Exception)
            {
                throw;

            }


















            //if (!_context.Medicines.Any())
            //{
            //    List<Medicine> medicines = new List<Medicine>();

            //    for (int i = 1; i <= 20; i++)
            //    {
            //        medicines.Add(new Medicine
            //        {
            //            Id = i,
            //            Name = $"Medicine {i}",
            //            Type = $"Type {i}",
            //            discreaption = "Description",
            //            Coust = i * 10.0m, // Example cost calculation
            //            expireddate = DateTime.Now.AddDays(-i),
            //            prouductiondate = DateTime.Now.AddMonths(i),

            //        });
            //        _context.Medicines.AddRange(medicines);
            //        _context.SaveChanges();
            //    }
            //}












            if (!_context.weekDays.Any())
                {
                    var weekDays = new List<WeekDays>
            {
                new WeekDays { WeekDaysName = "Sunday" , StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am" },
                new WeekDays { WeekDaysName = "Monday" ,StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am" },
                new WeekDays { WeekDaysName = "Tuesday"  ,StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am" },
                new WeekDays { WeekDaysName = "Wednesday" ,StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am" },
                new WeekDays { WeekDaysName = "Thursday"  ,StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am"},
                new WeekDays { WeekDaysName = "Friday",StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am" },
                new WeekDays { WeekDaysName = "Saturday"  ,StratingAmShafit="8 AM to 5 Pm" , StartingPmShift ="5 Pm 8 Am"}
            };

                    _context.weekDays.AddRange(weekDays);
                    _context.SaveChanges();
                }





                if (!_Rolemanger.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
                {
                    _Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();



                    _Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();
                    _Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_patient)).GetAwaiter().GetResult();
                    _Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_User)).GetAwaiter().GetResult();
                    _Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Employee)).GetAwaiter().GetResult();
                _Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Nursing)).GetAwaiter().GetResult();
                    //_Rolemanger.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_SuperAdmin)).GetAwaiter().GetResult();






                //    _usermanger.CreateAsync(new ApplicationUser
                //    {



                //        PhoneNumber = "01066451058",
                //        EmailConfirmed = true,
                //        City = "zag",
                //        PostalCode = "55555555555555",
                //        UserName = "karim",
                //        Email = "Karim.1995@gmail.com",

                //    }, "Karim.1995@gmail.com").GetAwaiter().GetResult();

                }


            }
        }
    }
