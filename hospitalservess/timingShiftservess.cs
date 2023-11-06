using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using PagedList;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class timingShiftservess : ItimingShift
    {
        Ihospital IhospitalRepository { get; set; }

        private readonly UserManager<ApplicationUser> _user;


        private ApplicationDBcontext _db;
        public timingShiftservess(ApplicationDBcontext db, Hospitalserves ihospitalRepository, UserManager<ApplicationUser> user)
        {
            _db = db;
            IhospitalRepository = ihospitalRepository;
            _user = user;
        }













        public void Save(timingshiftVm entity)
        {
              using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        var model = timingshiftVm.CanconvertViewmodel(entity);


                        if (entity.id > 0)
                        {
                            _db.TimingShifts.Update(model);
                        }
                        else
                        {
                            var timshifting = _db.TimingShifts.Add(model);

                        _db.SaveChanges();
                        var DoctorTimingShift = new DoctorTimingShift
                            {
                                DoctorId = entity.applicatinUserdictorid,
                                TimingShiftId = timshifting.Entity.id
                            };

                            _db.DoctorTimingShift.Add(DoctorTimingShift);
                        }

                          _db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Handle and log exceptions here
                        transaction.Rollback();
                    }
                }


            }
        


   


        public void Delete(int id)
        {

            var mode = _db.TimingShifts.Find(id);
            var DoctorTimingShift = _db.DoctorTimingShift.FirstOrDefault(m => m.TimingShiftId == id);
            _db.SaveChanges();

            _db.TimingShifts.Remove(mode);
            _db.SaveChanges();


        }

        public IEnumerable<timingshiftVm> GetAll()
        {
            var models = _db.TimingShifts
                .Include(ts => ts.DoctorTimingShifts)
                .ThenInclude(dts => dts.Doctor)
                .Select(p => new timingshiftVm
                {
                    id = p.id,
                    startshift = p.startshift,

                    Endsifit = p.Endsifit,
                    Duration = (double)p.Duration,
                    Stutus = p.Stutus,
                    doctorName =p.DoctorTimingShifts.FirstOrDefault().Doctor.UserName,
                })
                .ToList().OrderBy(p=>p.Endsifit);

            return models;
        }








    








        public timingshiftVm GetById(int id)
        {
           
            return _db.TimingShifts.Include(p=>p.DoctorTimingShifts).ThenInclude(p=>p.Doctor).Where(p => p.id == id).Select(p => new timingshiftVm
            {
                id = p.id,
            
                startshift = p.startshift,
                Endsifit = p.Endsifit,
                Duration = (double)p.Duration,
                Stutus = p.Stutus,
                doctorName=p.DoctorTimingShifts.Where(i=>i.TimingShiftId==id).FirstOrDefault().Doctor.UserName

            }).FirstOrDefault();
        }


















     


























        #region pagnation

        public PagedREsult<timingshiftVm> Getallpag(int pagnumber, int pagesize)
        {
            int totalcount;
            var Vmlist = new List<timingshiftVm>();

            try
            {
                int Excluderecored = (pagesize * pagnumber) - pagesize;
                var molist = GetAll().Skip(Excluderecored).Take(pagesize).ToList();
                totalcount = GetAll().ToList().Count;

                Vmlist = molist;





            }
            catch (Exception) { throw; }


            var rsult = new PagedREsult<timingshiftVm>
            {

                Data = Vmlist,
                pageSize = pagesize,
                TotalItens = totalcount,
                pageNumber = pagnumber,


            };
            return rsult;


        }

       


        #endregion

    }




}
