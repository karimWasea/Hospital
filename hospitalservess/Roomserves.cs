using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class Roomserves : IGenericRepository<RoomVm> ,IRoom
    {
        Ihospital IhospitalRepository { get; set; }



        private ApplicationDBcontext _db;
        public Roomserves(ApplicationDBcontext db , Hospitalserves ihospitalRepository)
        {
            _db = db;
            IhospitalRepository = ihospitalRepository;
        }













        public void Save(RoomVm entity)
        {


            var model = RoomVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                _db.GetRooms.Update(model);

                _db.SaveChanges();


            }
            else
            {


                _db.GetRooms.Add(model);

                _db.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            var  mode = _db.GetRooms.Find(id);


            _db.GetRooms.Remove(mode);
            _db.SaveChanges();



        }

        public IEnumerable<RoomVm> GetAll()
        {
            var model = _db.GetRooms.Select(p => new RoomVm
            {
               id = p.id,
RoomName = p.RoomName   ,
hospitalid = p.hospitalid,
    Stuts = p.Stuts,
    type = p.type,
  hospitalname = _db.Hospitals.Where(c => c.id ==p.hospitalid ).Select(p => p.Name).FirstOrDefault(),



            }).ToList();

            return model;
        }

        public RoomVm GetById(int id)
        {
            return _db.GetRooms.Where(p => p.id == id).Select(p => new RoomVm
            {
                hospitalname = _db.Hospitals.Where(p => p.id == id).Select(p=>p.Name).FirstOrDefault(),

                id = p.id,
                RoomName = p.RoomName,
                hospitalid = p.hospitalid,
                Stuts = p.Stuts,
                type = p.type,

            }).FirstOrDefault();
        }

       
        

      

     

       
      

       
     
     
       

      

        public Task<RoomVm> DeleteAcync(RoomVm entity)
        {
            throw new NotImplementedException();
        }
        public async Task<RoomVm> SaveAsync(RoomVm entity)
        {
            var model = RoomVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
            var m=    _db.GetRooms.Update(model);
                await _db.SaveChangesAsync();
                return GetById(m.Entity.id);
                // Use async SaveChangesAsync()

            }
            else
            {
             var m = _db.GetRooms.Add(model);

                await _db.SaveChangesAsync(); // Use async SaveChangesAsync()
                return GetById(m.Entity.id);


            }


        }

   

   






















    #region pagnation

    public PagedREsult<RoomVm> Getallpag(int pagnumber, int pagesize)
    {
        int totalcount;
        var Vmlist = new List<RoomVm>();

        try
        {
            int Excluderecored = (pagesize * pagnumber) - pagesize;
            var molist = GetAll().Skip(Excluderecored).Take(pagesize).ToList();
            totalcount = GetAll().ToList().Count;

            Vmlist = molist;





        }
        catch (Exception) { throw; }


        var rsult = new PagedREsult<RoomVm>
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
