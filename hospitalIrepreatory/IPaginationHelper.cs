using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

using PagedList;

namespace hospitalIrepreatory
{

        public interface IPaginationHelper<T>
        {
            IPagedList<T> GetPagedData<T>(IEnumerable<T> data, int pageNumber);
        }
    


}




