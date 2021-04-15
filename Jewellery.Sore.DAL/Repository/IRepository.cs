using Jewellery.Store.DAL.Entity;

namespace Jewellery.Store.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetAsync(long id);
    }
}
