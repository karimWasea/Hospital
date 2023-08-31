using hospitalUtilities;
using hospitalVm;

namespace hospitalIrepreatory
{
    public interface IRoom : IGenericRepository<RoomVm>
    {

        PagedREsult<RoomVm> Getallpag(int pagnumber, int pagesize);

    }
}