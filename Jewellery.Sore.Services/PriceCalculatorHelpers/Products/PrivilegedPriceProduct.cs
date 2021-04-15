using Jewellery.Store.ViewModels.Models;
using System;

namespace Jewellery.Store.Services.PriceCalculatorHelpers.Products
{
    public class PrivilegedPriceProduct : PriceProduct
    {
        private readonly IPriceCalculatorService _priceCalculatorService;
        public PrivilegedPriceProduct(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService = priceCalculatorService;
        }

        public override PriceCalculatorResponse CalculatePrice(PriceRequest request)
        {
            var price = base.CalculatePrice(request);
            var discount = _priceCalculatorService.GetDiscount(request.UserType);

            price.Discount = discount.Discount;
            var finalPrice = price.TotalPrice - ((price.TotalPrice * discount.Discount) / 100) ?? 0;
            price.TotalPrice = Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);
            return price;
        }
    }
}
