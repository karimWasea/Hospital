using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

using PagedList;

namespace hospitalIrepreatory
{
   public interface IPatient: IPaginationHelper<PatientVm>
    {
    

        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);


        Task<PatientVm> GetBy(string id);


        Task Save(PatientVm entity);
        //Task<IEnumerable<DoctorVm>> GetAllDoctorRegester(string searchTerm = null);



        Task<IPagedList<PatientVm>> Search(int? pagnumber, string searchTerm = null);








    }






}


