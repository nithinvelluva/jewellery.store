using Jewellery.Store.DAL.Entity;
using System.Collections.Generic;

namespace Jewellery.Store.DAL.Repository
{
  public interface IPetRepository : IRepository<PetEntity>
  {
    IList<PetEntity> GetByOwnerIdAsync(long ownerId);
  }
}
