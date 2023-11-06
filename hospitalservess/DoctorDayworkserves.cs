using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;
using hospitalUtilities.SystemEnums;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System;
using System.Linq.Expressions;

namespace hospitalservess
{

    public class DoctorDayworkserves : PaginationHelper<DoctorDayworkVM>, IGenericRepository<DoctorDayworkVM>, Idoctodayworinweek
    {

        lookupServess _lookupServess;

        UserManager<ApplicationUser> _userManager;
        private ApplicationDBcontext _db;
        public DoctorDayworkserves(ApplicationDBcontext db, UserManager<ApplicationUser> userManager, lookupServess lookupServess

    )
        {
             _lookupServess = lookupServess;
            _userManager = userManager;
            _db = db;
        }













        public void Save(DoctorDayworkVM entity)
        {

            entity.DoctorDayworkId = _db.doctorDayworks.Where(i => i.DoctorId == entity.DoctorId && i.WeekDaystId == entity.WeekDaystId).Select(i => i.DoctorDayworkId).FirstOrDefault();
            var model = DoctorDayworkVM.CanconvertViewmodel(entity);

             //var docoridindatabas = _db.doctorDayworks.Where(i => i.DoctorId==entity.DoctorId&&i.WeekDaystId==entity.WeekDaystId).Select(i=>i.DoctorDayworkId).FirstOrDefault();
       // var daworkid = _db.doctorDayworks.Select(i => i.DoctorDayworkId).FirstOrDefault();
            if (entity.DoctorDayworkId > 0 )
            {

                _db.doctorDayworks.Update(model);

                _db.SaveChanges();

           
              


            }
            else
            {


                _db.doctorDayworks.Add(model);

                _db.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            var mode = _db.doctorDayworks.Find(id);


            _db.doctorDayworks.Remove(mode);
            _db.SaveChanges();



        }

      

public IEnumerable<DoctorDayworkVM> getall()
        {
            var model = _db.weekDays
                .Include(p => p.DoctorDayworks) // Include the related entity WeekDays
                .Select(p => new DoctorDayworkVM
                {
                    // GetDoctors = _lookupServess.GetDoctorFromApplicationUserId(),
                    WeekDaystId =p.WeekDaysId, 
                    dayname = p.WeekDaysName,
                    StartingPmShift =p.StartingPmShift,
                    StratingAmShafit = p.StratingAmShafit,
                   //  DoctorDayworkId = p.DoctorDayworks.Where(p=>p.WeekDaystId==p.WeekDaystId).Select(p=>p.DoctorDayworkId).FirstOrDefault(),
                 //   DoctorId = p.DoctorDayworks.Where(p => p.DoctorId == p.Doctor.Id).Select(p => p.DoctorId).FirstOrDefault(),
                })
                .ToList();

            return model;
        }













        public DoctorDayworkVM getallweekdays(string id   )
        {


            var model = _db.weekDays.Select(x => new DoctorDayworkVM
            {


                WeekDaystId = x.WeekDaysId,
                dayname = x.WeekDaysName,
                StartingPmShift = x.StartingPmShift,
                StratingAmShafit = x.StratingAmShafit,
                DoctorName = _userManager.Users.Where(i => i.Id == id).Select(p => p.UserName).FirstOrDefault(),
                DoctorId = id,


            }).FirstOrDefault();


            return model;



        }

        public DoctorDayworkVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorDayworkVM> GetAll()
        {
            var model = _db.doctorDayworks
                .Where(w=>w.FormalStartingShift!=SHifts.HasNosifits).Include(c => c.Doctor).Include(c=>c.WeekDays) // Include the related entity WeekDays
                .Select(p => new DoctorDayworkVM
                {
                    // GetDoctors = _lookupServess.GetDoctorFromApplicationUserId(),
                    WeekDaystId = p.WeekDaystId ,
                    dayname = p.WeekDays.WeekDaysName,
                    Hifts = p.FormalStartingShift,
                     DoctorDayworkId = p.DoctorDayworkId,
                      DoctorId =p.DoctorId,
                      DoctorName=_userManager.Users.Where(i=>i.Id==p.DoctorId).Select(p => p.UserName).FirstOrDefault(),                                        
                })
                .ToList();

            return model;
        }



        //    #region
        //    public IEnumerable<DoctorDayworkVM> GetAll()
        //    {
        //        var model = _db.doctorDayworks.Select(p => new DoctorDayworkVM
        //        {
        //           DoctorDayworkId=p.DoctorDayworkId,
        //            DoctorId=p.DoctorId,
        //            // FormalEndingShift=p.FormalEndingShift,
        //             WeekDaystId=p.WeekDaystId,
        //           //  FormalStartingShift=p.FormalStartingShift,         



        //        }).ToList();

        //        return model;
        //    }

        //    public DoctorDayworkVM GetById(int id)
        //    {
        //        return _db.doctorDayworks.Where(p => p.DoctorDayworkId == id).Select(p => new DoctorDayworkVM
        //        {
        //            DoctorDayworkId = p.DoctorDayworkId,
        //            DoctorId = p.DoctorId,
        //           // FormalEndingShift = p.FormalEndingShift,
        //            WeekDaystId = p.WeekDaystId,
        //           // FormalStartingShift = p.FormalStartingShift,

        //        }).FirstOrDefault();
        //    }










        //    public void ADDRenge(List<DoctorDayworkVM> list)
        //    {

        //      List< DoctorDaywork> doctorDaywork = new (); 
        //         foreach (var item in list) {

        //           var model=  DoctorDayworkVM.CanconvertViewmodel(item);
        //            doctorDaywork.Add(model);   



        //        }
        //        _db.doctorDayworks.AddRange(doctorDaywork);
        //        _db.SaveChanges();
        //    }

        // form [moo]={}































        //    #region pagnation

        //    public PagedREsult< DoctorDayworkVM> Getallpag(int pagnumber, int pagesize)
        //{
        //    int totalcount;
        //    var Vmlist = new List<DoctorDayworkVM>();

        //    try
        //    {
        //        int Excluderecored = (pagesize * pagnumber) - pagesize;
        //        var molist = GetAll().Skip(Excluderecored).Take(pagesize).ToList();
        //        totalcount = GetAll().ToList().Count;

        //        Vmlist = molist;





        //    }
        //    catch (Exception) { throw; }


        //    var rsult = new PagedREsult<DoctorDayworkVM>
        //    {

        //        Data = Vmlist,
        //        pageSize = pagesize,
        //        TotalItens = totalcount,
        //        pageNumber = pagnumber,


        //    };
        //    return rsult;


        //}

        //    public IEnumerable<DoctorDayworkVM> Getallstatandendshiftbydoctorbydoctorid(string id)
        //    {
        //        throw new NotImplementedException();
        //    }




        //    #endregion






        //    #endregion all fun

        //}

    }


}
