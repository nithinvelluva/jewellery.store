using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.Services.PriceCalculatorHelpers
{
    public interface IPriceCalculator
    {
        PriceCalculatorResponse CalculatePrice(PriceRequest request);
    }
}
