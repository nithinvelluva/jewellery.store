using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.DAL.Repository;
using Jewellery.Store.Services.PriceCalculatorHelpers;
using Jewellery.Store.ViewModels.Models.Enums;

namespace Jewellery.Store.Services
{
    public class PriceCalculatorService : IPriceCalculatorService
    {        
        private readonly IPriceCalculatorRepository _priceCalculatorRepository;
        private readonly IPriceFactory _priceFactory;
        public PriceCalculatorService(        
        IPriceCalculatorRepository priceCalculatorRepository,
        IPriceFactory priceFactory
        )
        {
            _priceCalculatorRepository = priceCalculatorRepository;
            _priceFactory = priceFactory;
        }      

        public PriceCalculatorResponse CalculatePrice(PriceRequest request)
        {
            PriceCalculatorResponse response = null;
            if (request != null)
            {
                AbstractPriceCreateArg arg = new AbstractPriceCreateArg { UserType = (UserTypeEnum)request.UserType, PriceCalculatorService = this };
                var priceProduct = _priceFactory.Create(arg);
                response = priceProduct.Product.CalculatePrice(request);
            }
            return response;
        }

        public DiscountViewModel GetDiscount(long userType)
        {
            return new DiscountViewModel
            {
                Discount = _priceCalculatorRepository.GetDiscount(userType)
            };
        }
    }
}