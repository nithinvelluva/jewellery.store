using Jewellery.Store.DAL.Entity;

namespace Jewellery.Store.DAL.Repository
{
    public interface IPriceCalculatorRepository : IRepository<DiscountEntity>
    {
        long? GetDiscount(long userid);
    }
}
