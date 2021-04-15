using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.Services.PriceCalculatorHelpers.Products
{
    public class NormalPriceProduct : PriceProduct
    {
        private readonly IPriceCalculatorService _priceCalculatorService;
        public NormalPriceProduct(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService = priceCalculatorService;
        }
        public override PriceCalculatorResponse CalculatePrice(PriceRequest request)
        {
            return base.CalculatePrice(request);
        }
    }
}
