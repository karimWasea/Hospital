using hospitalUtilities;
using hospitalVm;

namespace hospitalIrepreatory
{
    public interface ItimingShift : IGenericRepository<timingshiftVm>
    {

        PagedREsult<timingshiftVm> Getallpag(int pagnumber, int pagesize);

    }
}