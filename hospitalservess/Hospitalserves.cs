using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class Hospitalserves : IGenericRepository<HospitalVm> ,Ihospital
    {




        private ApplicationDBcontext _db;
        public Hospitalserves(ApplicationDBcontext db)
        {
            _db = db;
        }













        public void Save(HospitalVm entity)
        {


            var model = HospitalVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
                _db.Hospitals.Update(model);

                _db.SaveChanges();


            }
            else
            {
                

                _db.Hospitals.Add(model);

                _db.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            Hospital? mode = _db.Hospitals.Find(id);


            _db.Hospitals.Remove(mode);
            _db.SaveChanges();



        }

        public IEnumerable<HospitalVm> GetAll()
        {
            var model = _db.Hospitals.Select(p => new HospitalVm
            {
                id = p.id,
                Name = p.Name,
                City = p.City,
                Type = p.Type,
                Country = p.Country,
                Pincode = p.Pincode,




            }).ToList();

            return model;
        }

        public HospitalVm GetById(int id)
        {
            return _db.Hospitals.Where(p => p.id == id).Select(p => new HospitalVm
            {
                id = p.id,
                Name = p.Name,
              City=p.City,
              Type=p.Type,
               Country=p.Country,
               Pincode=p.Pincode,

            }).FirstOrDefault();
        }

       
        

      

     

       
      

       
     
     
       

      

        public Task<HospitalVm> DeleteAcync(HospitalVm entity)
        {
            throw new NotImplementedException();
        }
        public async Task<HospitalVm> SaveAsync(HospitalVm entity)
        {
            var model = HospitalVm.CanconvertViewmodel(entity);

            if (entity.id > 0)
            {
            var m=    _db.Hospitals.Update(model);
                await _db.SaveChangesAsync();
                return GetById(m.Entity.id);
                // Use async SaveChangesAsync()

            }
            else
            {
              EntityEntry<Hospital>? m=  _db.Hospitals.Add(model);

                await _db.SaveChangesAsync(); // Use async SaveChangesAsync()
                return GetById(m.Entity.id);


            }


        }

   

   






















    #region pagnation

    public PagedREsult<HospitalVm> Getallpag(int pagnumber, int pagesize)
    {
        int totalcount;
        var Vmlist = new List<HospitalVm>();

        try
        {
            int Excluderecored = (pagesize * pagnumber) - pagesize;
            var molist = GetAll().Skip(Excluderecored).Take(pagesize).ToList();
            totalcount = GetAll().ToList().Count;

            Vmlist = molist;





        }
        catch (Exception) { throw; }


        var rsult = new PagedREsult<HospitalVm>
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
