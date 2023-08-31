using hospitalUtilities;
using hospitalVm;

namespace hospitalIrepreatory
{
    public interface Idoctorvist : IGenericRepository<ApointmentVm> ,IPaginationHelper<ApointmentVm> {

        IEnumerable<ApointmentVm> getvistitsbydoctorid( string id );
        IEnumerable<ApointmentVm> getvistitsbypatientid(string id);
       IEnumerable<ApointmentVm> GetAll(int pageNumber);

    }
}


