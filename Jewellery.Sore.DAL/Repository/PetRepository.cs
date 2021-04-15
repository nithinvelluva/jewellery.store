using Jewellery.Store.DAL.DBContext;
using Jewellery.Store.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery.Store.DAL.Repository
{
  public class PetRepository : BaseRepository<PetEntity>, IPetRepository
  {
    public PetRepository(MainDbContext dbContext) : base(dbContext)
    {
    }

    public override Task<long> DeleteAsync(long id)
    {
      throw new System.NotImplementedException();
    }

    public override IEnumerable<PetEntity> GetAsync()
    {
      throw new System.NotImplementedException();
    }

    public override PetEntity GetAsync(long id)
    {
      throw new System.NotImplementedException();
    }

    public IList<PetEntity> GetByOwnerIdAsync(long ownerId)
    {
      return _dbContext.Pets.Where(p => p.owner_id == ownerId).ToList();
    }

    public override async Task<long> InsertAsync(PetEntity data)
    {
      if (data == null) return 0;
      var pet = new PetEntity
      {
        owner_id = data.owner_id,
        name = data.name,
        type = data.type,
        age = data.age
      };
      _dbContext.Pets.Add(pet);
      await _dbContext.SaveChangesAsync();
      return pet.id;
    }

    public override async Task<bool> UpdateAsync(PetEntity data)
    {
      if (data == null) return false;
      var pet = _dbContext.Pets.Find(data.id);
      if (pet != null)
      {
        pet.owner_id = data.owner_id;
        pet.name = data.name;
        pet.type = data.type;
        pet.age = data.age;
      }
      await _dbContext.SaveChangesAsync();

      return true;
    }
  }
}
