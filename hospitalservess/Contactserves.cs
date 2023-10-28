using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;

namespace hospitalservess
{

    public class Contactserves : PaginationHelper<ContactVm>, IGenericRepository<ContactVm> ,IContact
    {

         Ihospital _Ihospital { get; set; }  


        private ApplicationDBcontext _db;
        public Contactserves(ApplicationDBcontext db , Hospitalserves ihospital)
        {
            _db = db;
            _Ihospital = ihospital; 
        }













        public void Save(ContactVm entity)
        {


            var model = ContactVm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _db.Contacts.Update(model);

                _db.SaveChanges();


            }
            else
            {
                

                _db.Contacts.Add(model);

                _db.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            var mode = _db.Contacts.Find(id);


            _db.Contacts.Remove(mode);
            _db.SaveChanges();



        }

        public IEnumerable<ContactVm> GetAll()
        {
            var model = _db.Contacts.Select(p => new ContactVm
            {
                Hospitalname= _Ihospital.GetById(p.hospitalid).Name,
                 hospitalid = p.hospitalid,
                 Email= p.Email ,
                 phone = p.phone ,
                 Id = p.id ,



            }).ToList();

            return model;
        }

        public ContactVm GetById(int id)
        {
            return _db.Contacts.Where(p => p.id == id).Select(p => new ContactVm
            {
                Hospitalname = _Ihospital.GetById(p.hospitalid).Name,

                hospitalid = p.hospitalid,
                Email = p.Email,
                Id = p.id,

                phone = p.phone,

            }).FirstOrDefault();
        }

       
        

      

     

       
      

       
     
     
       

      

        public Task<HospitalVm> DeleteAcync(HospitalVm entity)
        {
            throw new NotImplementedException();
        }
        public async Task<ContactVm> SaveAsync(ContactVm entity)
        {
            var model = ContactVm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
            var m=    _db.Contacts.Update(model);
                await _db.SaveChangesAsync();
                return GetById(m.Entity.id);
                // Use async SaveChangesAsync()

            }
            else
            {
              var  m=  _db.Contacts.Add(model);

                await _db.SaveChangesAsync(); // Use async SaveChangesAsync()
                return GetById(m.Entity.id);


            }


        }

   

   






















    #region pagnation

    public PagedREsult<ContactVm> Getallpag(int pagnumber, int pagesize)
    {
        int totalcount;
        var Vmlist = new List<ContactVm>();

        try
        {
            int Excluderecored = (pagesize * pagnumber) - pagesize;
            var molist = GetAll().Skip(Excluderecored).Take(pagesize).ToList();
            totalcount = GetAll().ToList().Count;

            Vmlist = molist;





        }
        catch (Exception) { throw; }


        var rsult = new PagedREsult<ContactVm>
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
