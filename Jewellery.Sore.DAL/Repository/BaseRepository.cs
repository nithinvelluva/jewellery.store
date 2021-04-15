using Jewellery.Store.DAL.DBContext;
using Jewellery.Store.DAL.Entity;

namespace Jewellery.Store.DAL.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly MainDbContext _dbContext;

        public BaseRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
        public abstract TEntity GetAsync(long id);
    }
}
