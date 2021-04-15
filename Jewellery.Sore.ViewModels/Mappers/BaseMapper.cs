using Jewellery.Store.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.ViewModels.Mapper
{
  public abstract class BaseMapper<TEntity, TViewModel> : IMapper<TEntity, TViewModel> where TEntity : class, IEntity
  where TViewModel : BaseViewModel
  {
    public abstract TEntity Decode(TViewModel data);
    public abstract TViewModel Encode(TEntity data);

    public virtual IEnumerable<TEntity> Decode(IEnumerable<TViewModel> data) => data?.Select(r => Decode(r));
    public virtual IList<TViewModel> Encode(IList<TEntity> data) => data?.Select(r => Encode(r)).ToList();
  }
}
