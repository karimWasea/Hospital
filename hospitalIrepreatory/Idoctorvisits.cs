using hospitalUtilities;
using hospitalVm;

using PagedList;

namespace hospitalIrepreatory
{
    public interface Idoctorvist : IGenericRepository<ApointmentVm> ,IPaginationHelper<ApointmentVm> {


        IPagedList<ApointmentVm> GettAllVistitsByDoctorid( string id ,int? pagnumber, string searchTerm = null);
        IPagedList<ApointmentVm> GetAllVistitsbyPatientid (string id,int? pagnumber, string searchTerm = null);
        IPagedList<ApointmentVm> GetAllVaisits (int? pagnumber, string searchTerm = null);

    }
}


