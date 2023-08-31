using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

namespace hospitalIrepreatory
{
    public interface Apointmentservesses : IGenericRepository<ApointmentVm>
    {
        Task< ApointmentVm> GetAvilablebydocid(string id);
        IEnumerable< ApointmentVm> GetBookingAppiontmentbydocid(string id);
            PagedREsult<ApointmentVm> Getallpag(int pagnumber, int pagesize);
        
    }


}