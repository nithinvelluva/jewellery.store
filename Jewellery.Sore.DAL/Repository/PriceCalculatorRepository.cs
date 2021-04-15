using Jewellery.Store.DAL.Entity;
using System;
using System.Linq;
using Jewellery.Store.DAL.DBContext;

namespace Jewellery.Store.DAL.Repository
{
    public class PriceCalculatorRepository : BaseRepository<DiscountEntity>, IPriceCalculatorRepository
    {
        public PriceCalculatorRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
        public override DiscountEntity GetAsync(long id)
        {
            throw new NotImplementedException();
        }       

        public long? GetDiscount(long userType)
        {
            var queryable = from discount in _dbContext.Discounts                            
                            where discount.usertype == userType
                            select new DiscountEntity
                            {
                                discount = discount.discount
                            };
            return queryable.FirstOrDefault()?.discount;
        }
    }
}