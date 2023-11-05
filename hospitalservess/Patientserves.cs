using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



using PagedList;



using System.Transactions;

namespace hospitalservess
{

    public class Patientserves : PaginationHelper<PatientVm>, IPatient
    {

        Imgoeration _lookupServess;
        private readonly UserManager<ApplicationUser> _user;


        private ApplicationDBcontext _db;
        public Patientserves(ApplicationDBcontext db, UserManager<ApplicationUser> user, Imgoeration lookupServess)
        {

            _lookupServess = lookupServess;
            _user = user;
            _db = db;
        }


        public async Task Save(PatientVm entity)
        {


            if (entity.id != null && entity.id != string.Empty)
            {
                // Update existing entity
                var existingUser = await _user.FindByIdAsync(entity.id);

                // Update properties of existingUser

                existingUser.Nationality = entity.Nationality;




                existingUser.Email = entity.Email;
                existingUser.Gender = entity.Gender;
                existingUser.RoleRegeseter = entity.RoleRegeseter;

                existingUser.imphgurl = entity.imphgurl;
                existingUser.PhoneNumber = entity.Phonenumber;
                existingUser.PostalCode = entity.PostalCode;
                existingUser.StreetAddress = entity.StreetAddress;
                existingUser.UserName = entity.username;

                if (entity.imgurlupdated == null)


                {
                    existingUser.imphgurl = _user.Users.Where(x => x.Id == entity.id).Select(e => e.imphgurl).FirstOrDefault();
                }
                else
                {

                    existingUser.imphgurl = _lookupServess.Addrengofimges(entity.imgurlupdated);
                }






                var updateResult = await _user.UpdateAsync(existingUser);

                _db.SaveChanges();
            }
            else
            {


                var model = new ApplicationUser
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




                };


                using (var transactionScope = new TransactionScope())
                {


                    //var model = DoctorVm.CanconvertViewmodel(entity);

                    //var updateResult = _user.CreateAsync(model, "");

                    // Add the model to the DbContext
                    _db.Add(model);

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
       





        public async Task<IPagedList<PatientVm>> Search(int? Pagenumber, string searchTerm = null)
        {
            var searchTermLower = searchTerm?.ToLower();
            int pageNum = Pagenumber ?? 1;

            var doctorsList = await _user.Users
                .Where(a => a.RoleRegeseter == RoleRegeseter.Patient &&
                           
                
                
                

                            (string.IsNullOrWhiteSpace(searchTerm) ||
                            EF.Functions.Like(a.UserName, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.StreetAddress, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.City, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Email, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Title, "%" + searchTermLower + "%") ||
                            EF.Functions.Like(a.Nationality, "%" + searchTermLower + "%")))
                .Select(ApplicationUser => new PatientVm
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

             

                })
                .ToListAsync();
            var paglist = GetPagedData(doctorsList, pageNum);

            return paglist;
        }

        public Task<PatientVm> GetBy(string id)
        {
            var model =  
                      _user.Users.Where(p => p.Id == id).Select(ApplicationUser => new PatientVm
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

                 






                      }).FirstOrDefaultAsync();
            return model;
        }
    }
}

