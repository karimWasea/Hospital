using Dataaccesslayer;
using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Newtonsoft.Json.Linq;

using PagedList;

using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Transactions;

namespace hospitalservess
{

    public class Doctorserves : PaginationHelper<DoctorVm>,IDoctor
    {
        Imgoeration _lookupServess;
        private readonly UserManager<ApplicationUser> _user;
        Idoctodayworinweek idoctodayworinweek;


        private ApplicationDBcontext _db;
        public Doctorserves(ApplicationDBcontext db, UserManager<ApplicationUser> user , Imgoeration lookupServess , DoctorDayworkserves doctorDayworkserves )
        {
            idoctodayworinweek = doctorDayworkserves;
            _lookupServess = lookupServess;
            _user = user;
            _db = db;
        }
    

        public async Task Save(DoctorVm entity)
        {


            if (entity.id != null && entity.id!=string.Empty)
            {
                // Update existing entity
                var existingUser = await _user.FindByIdAsync(entity.id);
             
                // Update properties of existingUser
                existingUser.Salary = entity.Salary;
                    existingUser.Nationality = entity.Nationality;
                    existingUser.spicialist = entity.spicialist;
                    existingUser.Title=entity.Title; existingUser.WorkingDaysinWeek=entity.WorkingDaysinWeek;  
                    existingUser.Contracturl=entity.Contracturl;
                     existingUser.HiringDate=entity.HiringDate;
                     existingUser.Email=entity.Email;
                     existingUser.Gender=entity.Gender;
                     existingUser.RoleRegeseter=entity.RoleRegeseter;
                     existingUser.HiringDate=entity.HiringDate;
                     existingUser.imphgurl=entity.imphgurl;
                     existingUser.PhoneNumber=entity.Phonenumber;
                     existingUser.PostalCode=entity.PostalCode;
                     existingUser.StreetAddress=entity.StreetAddress;
                     existingUser.UserName=entity.username;

                if (entity.imgurlupdated == null)


                {
                    existingUser.imphgurl = _user.Users.Where(x => x.Id == entity.id).Select(e => e.imphgurl).FirstOrDefault();
                }
                else
                {

                   existingUser.imphgurl = _lookupServess.Addrengofimges(entity.imgurlupdated);
                }



                existingUser.statusDoctorInSystem = entity.StatusDoctorInSystem;

                 
                        var updateResult = await _user.UpdateAsync(existingUser);
                       
                          _db.SaveChanges();
                    }
            else
            {


          var model=    new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = entity.username,

                    Email = entity.Email,
                    RoleRegeseter = entity.RoleRegeseter,
                    Gender = entity.Gender,
                    StreetAddress = entity.StreetAddress,
                    City = entity.City,
                    Dateofbarth = entity.Dateofbarth,
                    PhoneNumber = entity.Phonenumber,
                    Nationality = entity.Nationality,
                    imphgurl = _lookupServess.Addrengofimges(entity.imgurlupdated),
                    PostalCode = entity.PostalCode,
                    Title = entity.Title,
                    HiringDate = entity.HiringDate,
                    Contracturl = _lookupServess.Addrengofimges(entity.Contracturluplod),
                    statusDoctorInSystem = entity.StatusDoctorInSystem,
                    WorkingDaysinWeek = entity.WorkingDaysinWeek,
                    Salary = entity.Salary,
                };


                using (var transactionScope = new TransactionScope())
                {


                    //var model = DoctorVm.CanconvertViewmodel(entity);

                    //var updateResult = _user.CreateAsync(model, "");

                    // Add the model to the DbContext
                    _db.Add(model);
                    await _user.AddToRoleAsync(model, WebSiteRoles.WebSite_SuperAdmin);

                    // Save changes to the database
                    int rowsAffected = _db.SaveChanges();

                    // Commit the transaction
                    transactionScope.Complete();

                    // Return the number of rows affected

                }
            }
          
        }



        public async Task<bool> Delete(string id)
        {
            try
            {
               var listworkdays=  _db.doctorDayworks.Where(i => i.DoctorId == id).Select(i => i).ToList();
                _db.doctorDayworks.RemoveRange(listworkdays);
                _db.SaveChanges();
                var user = await _user.FindByIdAsync(id);
                
                if (user != null)
                {
                    var roles = await _user.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        await _user.RemoveFromRoleAsync(user, role);
                    }

                    var result = await _user.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        await _db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        // Handle user deletion failure
                        foreach (var error in result.Errors)
                        {
                            // Log or handle each error message
                        }
                        return false;
                    }
                }
                else
                {
                    // Handle user not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // Log the exception details for troubleshooting
                return false;
            }
        }
        public async Task<IEnumerable<DoctorVm>> GetallconfirmedDoctor()
    {
            var _users = await _user.Users.Where(ApplicationUser => ApplicationUser.RoleRegeseter == RoleRegeseter.Doctor&& ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Confirmed).Select(ApplicationUser => new DoctorVm
            {
                id = ApplicationUser.Id,
                username = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                RoleRegeseter = ApplicationUser.RoleRegeseter,
                Gender = ApplicationUser.Gender,
                StreetAddress = ApplicationUser.StreetAddress,
                City = ApplicationUser.City,
                Dateofbarth = ApplicationUser.Dateofbarth,
                Phonenumber = ApplicationUser.PhoneNumber,
                Nationality = ApplicationUser.Nationality,
                imphgurl = ApplicationUser.imphgurl,
                PostalCode = ApplicationUser.PostalCode,
                Title = ApplicationUser.Title,
                HiringDate = ApplicationUser.HiringDate,
                Contracturl = ApplicationUser.Contracturl,
                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

                WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                Salary = ApplicationUser.Salary,



            }).ToListAsync();

            return _users;
        }
        
        public async Task<DoctorVm>GetByIdasRegisterdoctor(string id)
        {
            var model =await
             _user.Users.Where(p => p.Id == id && p.statusDoctorInSystem == Cofimationdoctor.Regeseter).Select(ApplicationUser => new DoctorVm
            {
                id = ApplicationUser.Id,
                username = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                RoleRegeseter = ApplicationUser.RoleRegeseter,
                Gender = ApplicationUser.Gender,
                StreetAddress = ApplicationUser.StreetAddress,
                City = ApplicationUser.City,
                Dateofbarth = ApplicationUser.Dateofbarth,
                Phonenumber = ApplicationUser.PhoneNumber,
                Nationality = ApplicationUser.Nationality,
                imphgurl = ApplicationUser.imphgurl,
                PostalCode = ApplicationUser.PostalCode,
                Title = ApplicationUser.Title,
                HiringDate = ApplicationUser.HiringDate,
                Contracturl = ApplicationUser.Contracturl,
                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

                WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                Salary = ApplicationUser.Salary,





            }).FirstOrDefaultAsync();
            return model;   
        }


    

      


        public async Task<DoctorVm> GetByIdasconfirmed(string id)
        {
      // && p.statusDoctorInSystem == Cofimationdoctor.Regeseter
            var model = await
             _user.Users.Where(p => p.Id == id ).Select(ApplicationUser => new DoctorVm
             {
                 id = ApplicationUser.Id,
                 username = ApplicationUser.UserName,

                 Email = ApplicationUser.Email,
                 RoleRegeseter = ApplicationUser.RoleRegeseter,
                 Gender = ApplicationUser.Gender,
                 StreetAddress = ApplicationUser.StreetAddress,
                 City = ApplicationUser.City,
                 Dateofbarth = ApplicationUser.Dateofbarth,
                 Phonenumber = ApplicationUser.PhoneNumber,
                 Nationality = ApplicationUser.Nationality,
                 imphgurl = ApplicationUser.imphgurl,
                 PostalCode = ApplicationUser.PostalCode,
                 Title = ApplicationUser.Title,
                 HiringDate = ApplicationUser.HiringDate,
                 Contracturl = ApplicationUser.Contracturl,
                 StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

                 WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                 Salary = ApplicationUser.Salary,





             }).FirstOrDefaultAsync();
            return model;
        }
      


        public async Task<IPagedList<DoctorVm>> Search(int? Pagenumber, string searchTerm = null )
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = Pagenumber ?? 1;

            var doctorsList = await _user.Users
                .Where(a => a.RoleRegeseter == RoleRegeseter.Doctor &&
                            a.statusDoctorInSystem == Cofimationdoctor.Confirmed &&
                            (string.IsNullOrWhiteSpace(searchTerm) ||
                            EF.Functions.Like(a.UserName, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.StreetAddress, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.City, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Email, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Title, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Nationality, "%" + searchTermLower + "%")))
                .Select(ApplicationUser => new DoctorVm
                {
                    id = ApplicationUser.Id,
                    username = ApplicationUser.UserName,
                    Email = ApplicationUser.Email,
                    RoleRegeseter = ApplicationUser.RoleRegeseter,
                    Gender = ApplicationUser.Gender,
                    StreetAddress = ApplicationUser.StreetAddress,
                    City = ApplicationUser.City,
                    Dateofbarth = ApplicationUser.Dateofbarth,
                    Phonenumber = ApplicationUser.PhoneNumber,
                    Nationality = ApplicationUser.Nationality,
                    imphgurl = ApplicationUser.imphgurl,
                    PostalCode = ApplicationUser.PostalCode,
                    Title = ApplicationUser.Title,
                    HiringDate = ApplicationUser.HiringDate,
                    Contracturl = ApplicationUser.Contracturl,
                    StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,
                    WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                    Salary = ApplicationUser.Salary
                })
                .ToListAsync();
         var paglist=   GetPagedData(doctorsList , pageNum);

            return paglist;
        }

        public async Task<IPagedList<DoctorVm>> GetAllDoctorRegester(int? pageNumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = pageNumber ?? 1;

            var query = _user.Users
                .Where(a => a.RoleRegeseter == RoleRegeseter.Doctor &&
                            a.statusDoctorInSystem == Cofimationdoctor.Regeseter &&
                            (string.IsNullOrWhiteSpace(searchTermLower) ||
                             EF.Functions.Like(a.UserName, "%" + searchTermLower + "%") ||
                             EF.Functions.Like(a.StreetAddress, "%" + searchTermLower + "%") ||
                             EF.Functions.Like(a.City, "%" + searchTermLower + "%") ||
                             EF.Functions.Like(a.Email, "%" + searchTermLower + "%") ||
                             EF.Functions.Like(a.Title, "%" + searchTermLower + "%") ||
                             EF.Functions.Like(a.Nationality, "%" + searchTermLower + "%"))
                )
                .Select(ApplicationUser => new DoctorVm
                {
                    id = ApplicationUser.Id,
                    username = ApplicationUser.UserName,
                    Email = ApplicationUser.Email,
                    RoleRegeseter = ApplicationUser.RoleRegeseter,
                    Gender = ApplicationUser.Gender,
                    StreetAddress = ApplicationUser.StreetAddress,
                    City = ApplicationUser.City,
                    Dateofbarth = ApplicationUser.Dateofbarth,
                    Phonenumber = ApplicationUser.PhoneNumber,
                    Nationality = ApplicationUser.Nationality,
                    imphgurl = ApplicationUser.imphgurl,
                    PostalCode = ApplicationUser.PostalCode,
                    Title = ApplicationUser.Title,
                    HiringDate = ApplicationUser.HiringDate,
                    Contracturl = ApplicationUser.Contracturl,
                    StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,
                    WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
                    Salary = ApplicationUser.Salary
                });

            var doctors = await query.ToListAsync();
            var pagedList = GetPagedData(doctors, pageNum);

            return pagedList;
        }


    }
}

