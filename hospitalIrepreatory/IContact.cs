using hospitalUtilities;
using hospitalVm;
using hospitalUtilities;
using hospitalVm;

namespace hospitalIrepreatory
{
    public interface IContact : IGenericRepository<ContactVm> ,IPaginationHelper<ContactVm>
    {

        PagedREsult<ContactVm> Getallpag(int pagnumber, int pagesize);

    }
}


