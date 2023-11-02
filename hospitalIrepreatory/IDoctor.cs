using Dataaccesslayer;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;
using PagedList;

namespace hospitalIrepreatory
{
   public interface IDoctor:IPaginationHelper<DoctorVm>
    {
        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<DoctorVm > GetByIdasRegisterdoctor(string id);
        Task<DoctorVm> GetByIdasconfirmed(string id);

        Task<IEnumerable<DoctorVm>> GetallconfirmedDoctor();


        Task Save(DoctorVm entity);
      //Task<IEnumerable<DoctorVm>> GetAllDoctorRegester(string searchTerm = null);



            Task<IPagedList<DoctorVm>> Search(int ?pagnumber, string searchTerm = null);
            Task<IPagedList<DoctorVm>> GetAllDoctorRegester(int ?pagnumber, string searchTerm = null);







    }


}