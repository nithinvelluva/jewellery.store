using Jewellery.Store.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jewellery.Store.Services
{
  public interface IPetOwnerService
  {
    IEnumerable<OwnerViewModel> GetOwnersAsync();
    OwnerViewModel GetOwnerAsync(long id);
    Task<bool> SaveOwnerAsync(OwnerViewModel model);
    Task<bool> DeleteOwnerAsync(long id);
    IList<PetViewModel> GetPetsByOwnerIdAsync(long ownerId);
    PetViewModel GetPetByIdAsync(long ownerId, long id);
    Task<bool> SavePetAsync(long ownerId, PetViewModel model);
    Task<bool> DeletePetAsync(object ownerId, long id);
  }
}
