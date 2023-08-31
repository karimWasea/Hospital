using Dataaccesslayer;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

namespace hospitalIrepreatory
{
    public interface Ihospital : IGenericRepository<HospitalVm>
    {
        
        PagedREsult<HospitalVm> Getallpag(int pagnumber, int pagesize);
        
    }


}