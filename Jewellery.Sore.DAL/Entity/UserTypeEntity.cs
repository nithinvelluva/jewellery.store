using System.Collections.Generic;

namespace Jewellery.Store.DAL.Entity
{
    public class UserTypeEntity : BaseEntity, IEntity
    {
        public string type { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }

        public virtual DiscountEntity Discount { get; set; }
    }
}
