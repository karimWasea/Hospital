using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using PagedList;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class timingShiftservess : IGenericRepository<timingshiftVm>, ItimingShift
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
            TimeSpan timeDifference = (TimeSpan)(entity. Endsifit - entity.startshift);
            int durationInMinutes = (int)timeDifference.TotalMinutes;
            entity.Duration=durationInMinutes;

            //if (Endsifit > StartShift)
            //{
            //    // Perform some action
            //}
            // entity.Duration =  entity.Endsifit - entity.startshift;



            var model = timingshiftVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                _db.TimingShifts.Update(model);

                _db.SaveChanges();


            }
            else
            {


                _db.TimingShifts.Add(model);

                _db.SaveChanges();


            }
        }


        //public int CalculateShiftDurationInMinutes()
        //{
        //    TimeSpan timeDifference = Endsifit - StartShift;
        //    int durationInMinutes = (int)timeDifference.TotalMinutes;
        //    return durationInMinutes;
        //}


        public void Delete(int id)
        {

            var mode = _db.TimingShifts.Find(id);


            _db.TimingShifts.Remove(mode);
            _db.SaveChanges();



        }

        public IEnumerable<timingshiftVm> GetAll()
        {
            var model = _db.TimingShifts.Select(p => new timingshiftVm
            {
                id = p.id,
                //AfternoonShiffttimStarttimePM = p.AfternoonShiffttimStarttimePM
                //,
                //AftornoonShiftfttimEndtimePM=p.AftornoonShiftfttimEndtimePM,
                //applicatinUserdictorid=p.ApplicationUserId,
                //MorningSifttimEndtimeAM=p.MorningSifttimEndtimeAM,
                startshift = p.startshift,
                Endsifit = p.Endsifit,
                Duration= (double)p.Duration,
                    //MorningSifttimStarttimeAM=p.MorningSifttimStarttimeAM,  
                    Stutus=p.Stutus,
                doctorName = _user.Users.Select(p => p.UserName).FirstOrDefault(),


            }).ToList();

            return model;
        }








       
            //public IPagedList<T> GetPagedData<T>(IQueryable<T> data, int pageNumber)
            //{
            //    int pageSize = 10; // Set the page size to 10
            //    int totalItemCount = GetAll().Count();
            //    int totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            //    pageNumber = Math.Max(1, Math.Min(totalPages, pageNumber));

            //    int startIndex = (pageNumber - 1) * pageSize;
            //    int endIndex = Math.Min(startIndex + pageSize - 1, totalItemCount - 1);

            //    var pagedData = data.Skip(startIndex).Take(pageSize).ToList();

            //    return new StaticPagedList<T>(pagedData, pageNumber, pageSize, totalItemCount);


            //}



        





            public timingshiftVm GetById(int id)
        {
            var getentity = _db.TimingShifts.Find(id);
            TimeSpan timeDifference = (TimeSpan)(getentity.Endsifit - getentity.startshift);
            int durationInMinutes = (int)timeDifference.TotalHours;
            getentity.Duration = durationInMinutes;
            return _db.TimingShifts.Where(p => p.id == id).Select(p => new timingshiftVm
            {
                id = p.id,
                //AfternoonShiffttimStarttimePM = p.AfternoonShiffttimStarttimePM
                //,
                //AftornoonShiftfttimEndtimePM = p.AftornoonShiftfttimEndtimePM,
                //applicatinUserdictorid = p.ApplicationUserId,
                //MorningSifttimEndtimeAM = p.MorningSifttimEndtimeAM,
                startshift = p.startshift,
                Endsifit = p.Endsifit,
                Duration = durationInMinutes,
                //MorningSifttimStarttimeAM = p.MorningSifttimStarttimeAM,
                Stutus = p.Stutus,

            }).FirstOrDefault();
        }


















        public Task<timingshiftVm> DeleteAcync(timingshiftVm entity)
        {
            throw new NotImplementedException();
        }
        public async Task<timingshiftVm> SaveAsync(timingshiftVm entity)
        {
            var model = timingshiftVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                var m = _db.TimingShifts.Update(model);
                await _db.SaveChangesAsync();
                return GetById(m.Entity.id);
                // Use async SaveChangesAsync()

            }
            else
            {
                var m = _db.TimingShifts.Add(model);

                await _db.SaveChangesAsync(); // Use async SaveChangesAsync()
                return GetById(m.Entity.id);


            }


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
