using hospitalVm;

using PagedList;

namespace hospitalIrepreatory
{
    public  interface Ipatientreportserves   : IPaginationHelper<patientreportVm>,IGenericRepository<patientreportVm>
    {
        IPagedList<patientreportVm> GetAllReportsbyPatientid(string id, int? pagnumber, string searchTerm = null);
        IPagedList<patientreportVm> Search( int? pagnumber, string searchTerm = null);

    }
}