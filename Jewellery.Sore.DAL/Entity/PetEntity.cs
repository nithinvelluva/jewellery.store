using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jewellery.Store.DAL.Entity
{
  public class PetEntity : BaseEntity, IEntity
  {
    public long owner_id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    [ForeignKey("owner_id")]
    public virtual OwnerEntity Owner { get; set; }

    public virtual ICollection<AppointmentEntity> Appointments { get; set; }
  }
}
