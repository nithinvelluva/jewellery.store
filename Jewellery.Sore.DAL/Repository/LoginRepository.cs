using Jewellery.Store.DAL.Entity;
using System;
using System.Linq;
using Jewellery.Store.DAL.DBContext;

namespace Jewellery.Store.DAL.Repository
{
    public class LoginRepository : BaseRepository<UserEntity>, ILoginRepository
    {
        public LoginRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
        public override UserEntity GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public UserEntity LoginAsync(string userName, string password)
        {
            var queryable = from user in _dbContext.Users
                            where user.user_name.Equals(userName) && user.password.Equals(password)
                            select new UserEntity
                            {
                                id = user.id,
                                usertype = user.usertype,
                                first_name = user.first_name,
                                last_name = user.last_name
                            };
            return queryable.FirstOrDefault();
        }

        public UserEntity GetUserInfo(int userid)
        {
            var queryable = from user in _dbContext.Users
                            join usertype in _dbContext.UserTypes on user.usertype equals usertype.id
                            join discount in _dbContext.Discounts on usertype.id equals discount.usertype
                            where user.id == userid
                            select new UserEntity
                            {
                                id = user.id,
                                first_name = user.first_name,
                                last_name = user.last_name,
                                usertype = user.usertype,

                                UserType = new UserTypeEntity
                                {
                                    type = usertype.type,
                                    Discount = new DiscountEntity
                                    {
                                        discount = discount.discount
                                    }
                                }
                            };
            return queryable.FirstOrDefault();
        }
    }
}