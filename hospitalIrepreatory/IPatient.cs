using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

namespace hospitalIrepreatory
{
   public interface IPatient: IPaginationHelper<PatientVm>
    {
        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
      Task<PatientVm> GetById(string id);
  Task<IEnumerable<PatientVm>> Getall();





        Task Save(PatientVm entity);






    }


}