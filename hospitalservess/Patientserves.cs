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

namespace hospitalservess
{

    public class Patientserves : PaginationHelper<PatientVm>, IPatient
    {
        Imgoeration _lookupServess;
        private readonly UserManager<ApplicationUser> _user;



        private ApplicationDBcontext _db;
        public Patientserves(ApplicationDBcontext db, UserManager<ApplicationUser> user , Imgoeration lookupServess )
        {
            _lookupServess = lookupServess;
            _user = user;
            _db = db;
        }
    
















        public async Task Save(PatientVm entity)
        {
            var model = PatientVm.CanconvertViewmodel(entity);

            if (entity.id != null)
            {
                // Update existing entity
                var existingUser = await _user.FindByIdAsync(entity.id);
             
                // Update properties of existingUser
                    existingUser.Nationality = entity.Nationality;
                    existingUser.Title=entity.Title; 
                     existingUser.Email=entity.Email;
                     existingUser.Gender=entity.Gender;
                     existingUser.RoleRegeseter=entity.RoleRegeseter;
                     existingUser.Dateofbarth=entity.Dateofbarth;
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

                   existingUser.imphgurl = _lookupServess.Uploadimg(entity.imgurlupdated);
                }




                 
                        var updateResult = await _user.UpdateAsync(existingUser);
                       
                        await _db.SaveChangesAsync();
                    }
            else
            {

                var updateResult = await _user.CreateAsync(model);

                await _db.SaveChangesAsync();   
            }
          
        }



        public async Task<bool> Delete(string id)
        {
            try
            {
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
   


        public async Task<IEnumerable<PatientVm>> Getall()
    {
            var _users = await _user.Users.Where(ApplicationUser => ApplicationUser.RoleRegeseter == RoleRegeseter.Patient).Select(ApplicationUser => new PatientVm
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
               


            }).ToListAsync();

            return _users;
        }













     
        public async Task<PatientVm> GetById(string id)
        {
      // && p.statusDoctorInSystem == Cofimationdoctor.Regeseter
            var model = await
             _user.Users.Where(p => p.Id == id &&p.RoleRegeseter==RoleRegeseter.Patient ).Select(ApplicationUser => new PatientVm
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
                 






             }).FirstOrDefaultAsync();
            return model;
        }

       
    }
}

