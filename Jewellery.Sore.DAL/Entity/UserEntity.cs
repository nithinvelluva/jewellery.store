using System.ComponentModel.DataAnnotations.Schema;

namespace Jewellery.Store.DAL.Entity
{
    public class UserEntity : BaseEntity, IEntity
    {
        public string first_name { get; set; }
        public string last_name { get; set; }

        public long usertype { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        [ForeignKey("usertype")]
        public virtual UserTypeEntity UserType { get; set; }
    }
}
