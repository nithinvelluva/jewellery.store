using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.Services
{
    public interface IPriceCalculatorService
    {
        PriceCalculatorResponse CalculatePrice(PriceRequest request);

        DiscountViewModel GetDiscount(long userType);
    }
}