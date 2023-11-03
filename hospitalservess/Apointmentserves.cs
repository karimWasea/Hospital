using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class Apointmentserves : PaginationHelper<ApointmentVm>, Apointmentservesses
    {
        IApplicationuser GetApplicationuser;
        Idoctorvist idoctorvist;
        UserManager<ApplicationUser> _userManager;

        private ApplicationDBcontext _db;
        public Apointmentserves(ApplicationDBcontext db, Hospitalserves ihospital, UserManager<ApplicationUser> userManager, Applicationuserserves applicationuserserves, idoctorvisittserves idoctorvisittserves)
        {
            idoctorvist = idoctorvisittserves;
            // GetApplicationuser = applicationuserserves;
            _db = db;
            _userManager = userManager;
        }













        public void Save(ApointmentVm entity)
        {


            var model = ApointmentVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                EntityEntry<Apointment>? save = _db.Apointment.Update(model);

            }
            else
            {


                EntityEntry<Apointment>? save = _db.Apointment.Add(model);

                _db.SaveChanges();

                entity.id = save.Entity.id;
                entity.VisitStatus = VisitStatus.Scheduled;

                idoctorvist.Save(entity);


            }
        }





        public void Delete(int id)
        {

            var mode = _db.Apointment.Find(id);


            _db.Apointment.Remove(mode);
            _db.SaveChanges();



        }

        public IEnumerable<ApointmentVm> GetAll()
        {
            var model = _db.Apointment.Select(p => new ApointmentVm
            {



            }).ToList();

            return model;
        }

        public ApointmentVm GetById(int id)
        {

            return _db.Apointment.Where(p => p.id == id).Select(p => new ApointmentVm
            {
                id = p.id,
                CreateDate = p.CreateDate,
                doctorid = p.discreaption,

            }).FirstOrDefault();
        }











        public async Task<ApointmentVm> GetAvilablebydocid(string id)
        {

            var _users = await _userManager.Users.Where(p => p.Id == id).Select(ap => new ApointmentVm
            {



                doctorid = ap.Id,
                DoctorName = ap.UserName,

            }).FirstOrDefaultAsync();
            return _users;
        }










        public Task<ApointmentVm> DeleteAcync(ApointmentVm entity)
        {
            throw new NotImplementedException();
        }
        public async Task<ApointmentVm> SaveAsync(ApointmentVm entity)
        {
            var model = ApointmentVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                var m = _db.Apointment.Update(model);
                await _db.SaveChangesAsync();
                return GetById(m.Entity.id);
                // Use async SaveChangesAsync()

            }
            else
            {
                var m = _db.Apointment.Add(model);

                await _db.SaveChangesAsync(); // Use async SaveChangesAsync()
                return GetById(m.Entity.id);


            }


        }









        #region pagnation

        public PagedREsult<ApointmentVm> Getallpag(int pagnumber, int pagesize)
        {
            int totalcount;
            var Vmlist = new List<ApointmentVm>();

            try
            {
                int Excluderecored = (pagesize * pagnumber) - pagesize;
                var molist = GetAll().Skip(Excluderecored).Take(pagesize).ToList();
                totalcount = GetAll().ToList().Count;

                Vmlist = molist;





            }
            catch (Exception) { throw; }


            var rsult = new PagedREsult<ApointmentVm>
            {

                Data = Vmlist,
                pageSize = pagesize,
                TotalItens = totalcount,
                pageNumber = pagnumber,


            };
            return rsult;


        }

        public IEnumerable<ApointmentVm> GetBookingAppiontmentbydocid(string id)
        {





            var model = _db.DoctorAppointmentVIsit.Include(i => i.patient).Include(i => i.Doctor).Where(i => i.DoctorId == id).Select(p => new ApointmentVm
            {

                DoctorName = _userManager.Users.Where(i => i.Id == id).Select(i => i.UserName).FirstOrDefault(),

                PatientName = _userManager.Users.Where(i => i.Id == p.patientid).Select(i => i.UserName).FirstOrDefault(),

                CreateDate = _db.Apointment.Where(i => i.id == p.AppointmentId && p.DoctorId == id).Select(i => i.CreateDate).FirstOrDefault(),
                VisitType = p.VisitType,
                VisitStatus = p.visitStatus,
                patientid = p.patientid,
                doctorid = id,


            }).ToList();
            return model;
        }


        #endregion

    }




}
