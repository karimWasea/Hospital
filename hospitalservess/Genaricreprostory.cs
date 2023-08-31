//using Dataaccesslayer;

//using hospitalIrepreatory;

//using Microsoft.EntityFrameworkCore;

//using System.Linq.Expressions;

//namespace hospitalservess
//{

//    public class Genaricreprostory<T> : IDisposable, IGenericRepository<T> where T : class

//    {


//        private readonly ApplicationDBcontext _context;
//        internal DbSet<T> _dbSet;

//        public Genaricreprostory(ApplicationDBcontext context)
//        {



//           _context= context;
//            _dbSet = _context.Set<T>();
//        }

//        public Genaricreprostory()
//        {
//        }

//        public T GetById(int id)
//        {
//            return _dbSet.Find(id);
//        }

//        public IEnumerable<T> GetAll()
//        {
//            return _dbSet.ToList();
//        }

//        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, IOrderedQueryable<T> orderby = null,
//            string includeProperty = "")
//        {
//            IQueryable<T> query = _dbSet;

//            if (filter != null)
//            {
//                query = query.Where(filter);
//            }

//            if (string.IsNullOrEmpty(includeProperty))
//            {
//                foreach (var includeProp in includeProperty
//                  .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//                {
//                    query = query.Include(includeProp);
//                }


//            }

//            if (orderby != null)
//            {
//                return query.ToList();
//            }

//            return query.ToList();
//        }

//        public void Add(T entity)
//        {
//            _dbSet.Add(entity);
//            _context.SaveChanges();

//        }



//        public void Update(T entity)
//        {
//            _dbSet.Update(entity);
//        }

//        public async Task<T> UpdateAcync(T entity)
//        {
//            _dbSet.Update(entity);
//            _context.SaveChanges();

//            return entity;
//        }

//        public void Delete(T entity)
//        {
//            _dbSet.Remove(entity);
//        }

//        public async Task<T> DeleteAcync(T entity)
//        {
//            _dbSet.Remove(entity);
//            _context.SaveChanges();

//            return entity;
//        }






//        #region genral function


//        public int Complete()
//        {

//            var nunber = _context.SaveChanges();
//            return nunber;


//        }
//        #endregion




//        public async Task<T> AddAcync(T entity)
//        {
//            _dbSet.Add(entity);
//            _context.SaveChanges();

//            return entity;
//        }



//        public async Task<T> DeleteAsync(T entity)
//        {


//            _dbSet.Remove(entity);
//            _context.SaveChanges();
//            return entity;
//        }





//        #region Implement the Dispose method to release resources
//        private bool disposed = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposed)
//            {
//                if (disposing)
//                {
//                    _context.Dispose();
//                }
//            }
//            disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

     


//        // Implement the finalizer to release unmanaged resources
//        ~Genaricreprostory()
//        {
//            Dispose(false);
//        }
//        #endregion

































//    }




//    }
