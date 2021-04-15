using System.ComponentModel.DataAnnotations.Schema;

namespace Jewellery.Store.DAL.Entity
{
    public class DiscountEntity : BaseEntity, IEntity
    {
        public long usertype { get; set; }

        public long? discount { get; set; }

        [ForeignKey("usertype")]
        public virtual UserTypeEntity UserType { get; set; }
    }
}
