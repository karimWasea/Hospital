using System.Linq.Expressions;

namespace hospitalIrepreatory
{
    public interface IGenericRepository<Tentity>  where Tentity : class
    {
        Tentity GetById(int id);
        IEnumerable<Tentity> GetAll();
        //IEnumerable<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null, IOrderedQueryable<Tentity> orderby = null,
        //    string includeproparty = "");
        void Save(Tentity entity);
      

        void Delete(int id );
    }
   

}