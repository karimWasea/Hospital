using Dataaccesslayer;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

namespace hospitalIrepreatory
{
   public interface IDoctor// IGenericRepository<DoctorVm>
    {
        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<DoctorVm > GetByIdasRegisterdoctor(string id);
        Task<DoctorVm> GetByIdasconfirmed(string id);

        Task<IEnumerable<DoctorVm>> GetallconfirmedDoctor();


        Task Save(DoctorVm entity);
      Task<IEnumerable<DoctorVm>> GetAllDoctorRegester( );






    }


}