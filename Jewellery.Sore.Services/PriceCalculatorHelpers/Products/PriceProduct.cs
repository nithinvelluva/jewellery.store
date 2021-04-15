using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.Services.PriceCalculatorHelpers.Products
{
    public class PriceProduct
    {
        public virtual PriceCalculatorResponse CalculatePrice(PriceRequest request)
        {
            return new PriceCalculatorResponse
            {
                GoldPrice = request.GoldPrice,
                Weight = request.Weight,
                TotalPrice = request.GoldPrice * request.Weight
            };
        }
    }
}
