using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;
using hospitalUtilities.SystemEnums;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Newtonsoft.Json;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class Applicationuserserves 
        // IApplicationuser
    {
        private readonly RoleManager<IdentityRole> _roles;

        private readonly UserManager<ApplicationUser> _user;


        private ApplicationDBcontext _db;
        public Applicationuserserves(UserManager<ApplicationUser> user, ApplicationDBcontext db, RoleManager<IdentityRole> roles
)
        {
            _roles=roles;
            _db = db;
            _user = user;

        }

         














        //public async Task SaveAcync(ApplicationuserVm entity)
        //{

        //    var model = ApplicationuserVm.CanconvertViewmodel(entity);



        //    if (entity.id != null)
        //    {
        //     await   _user.FindByIdAsync(entity.id); 

        //        await _user.UpdateAsync(model);
        //        _db.SaveChanges();



        //    }
        //    else
        //    {
        //        await _user.CreateAsync(model);
        //        _db.SaveChanges();

        //    }
        //}



        public async Task<ApplicationuserVm> GetByIdAsync(string id)
        {

            var _users = await _user.Users.Where(p => p.RoleRegeseter == RoleRegeseter.Doctor).Select(ap => new ApplicationuserVm
            {

                id = ap.Id,
                Nationality = ap.Nationality,
                City = ap.City,
                Dateofbarth = ap.Dateofbarth,
                Email = ap.Email,
                Gender = ap.Gender,
                imphgurl = ap.imphgurl,
                Phonenumber = ap.PhoneNumber,
                spicialist = ap.spicialist,
                StreetAddress = ap.StreetAddress,
                PostalCode = ap.PostalCode,
                RoleRegeseter = ap.RoleRegeseter,
                username = ap.UserName,
                 


            }).FirstOrDefaultAsync();
            return _users;
        }

        public async Task<IEnumerable<ApplicationuserVm>> GetAllAsync()
        {//_user.Users.Select(i=>i.Doctor)
            var _users = await _user.Users.Where(p => p.RoleRegeseter == RoleRegeseter.Doctor ).Select(ap => new ApplicationuserVm
            {

                id = ap.Id,
                Nationality = ap.Nationality,
                City = ap.City,
                Dateofbarth = ap.Dateofbarth,
                Email = ap.Email,
                Gender = ap.Gender,
                imphgurl = ap.imphgurl,
                Phonenumber = ap.PhoneNumber,
                spicialist = ap.spicialist,
                StreetAddress = ap.StreetAddress,
                PostalCode = ap.PostalCode,
                RoleRegeseter = ap.RoleRegeseter,
                username = ap.UserName,
                


            }).ToListAsync();
            return _users;
        }
    
        public async Task DeleteAcync(string id)

        {
            var user = await _user.FindByIdAsync(id);


            if (user != null)
            {
                var roles = await _user.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    await _user.RemoveFromRoleAsync(user, role);
                }

                await _db.SaveChangesAsync();
            }



               _db.Users.Remove(user);

            _db.SaveChanges();
        }
        #region pagnation

        //public Task< PagedREsult<ApplicationuserVm> > Getallpag(int pagnumber, int pagesize)
        //{
        //    int totalcount;
        //    var Vmlist = new List<ApplicationuserVm>();

        //    try
        //    {
        //        int Excluderecored = (pagesize * pagnumber) - pagesize;
        //        var molist = GetAllAsync().Skip(Excluderecored).Take(pagesize).ToList();
        //        totalcount = GetAllAsync().ToList().Count;

        //        Vmlist = molist;





        //    }
        //    catch (Exception) { throw; }


        //    var rsult = new PagedREsult<RoomVm>
        //    {

        //        Data = Vmlist,
        //        pageSize = pagesize,
        //        TotalItens = totalcount,
        //        pageNumber = pagnumber,


        //    };
        //    return rsult;


        //}


        #endregion

    }




}
