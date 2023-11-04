using Dataaccesslayer;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

using PagedList;

namespace hospitalIrepreatory
{
    public interface IPatientHistory  :IPaginationHelper<PatientHistoryVm>
    {

   void Delete(int id);



        public PatientHistoryVm GetById(int id);


        void Save(PatientHistoryVm entity);




        IPagedList<PatientHistoryVm> Search(int? pagnumber, string searchTerm = null);
        IPagedList<PatientHistoryVm> GetallPatientHistory(string Patientid, int? pagnumber, string searchTerm = null);
        

        }


}