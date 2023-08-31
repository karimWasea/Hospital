using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

using System.Linq.Expressions;

namespace hospitalIrepreatory
{
    public interface IApplicationuser //: IGenericRepository<ApplicationuserVm> 
    {
        
       // Task <PagedREsult<ApplicationuserVm>> Getallpag(int pagnumber, int pagesize);
         Task SaveAcync(ApplicationuserVm entity);
        Task DeleteAcync(string entity);
        Task<ApplicationuserVm> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationuserVm>> GetAllAsync();
      
    
    }


}