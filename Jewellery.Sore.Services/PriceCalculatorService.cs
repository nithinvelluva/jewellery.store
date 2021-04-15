using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.DAL.Repository;
using Jewellery.Store.Services.PriceCalculatorHelpers;
using Jewellery.Store.ViewModels.Mapper;
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
            AbstractPriceCreateArg arg = new AbstractPriceCreateArg { UserType = (UserTypeEnum) request.UserType , PriceCalculatorService = this };
            var priceProduct = _priceFactory.Create(arg);
            return priceProduct.Product.CalculatePrice(request);
        }

        public DiscountViewModel GetDiscount(long userId)
        {
            return new DiscountViewModel
            {
                Discount = _priceCalculatorRepository.GetDiscount(userId)
            };
        }
    }
}