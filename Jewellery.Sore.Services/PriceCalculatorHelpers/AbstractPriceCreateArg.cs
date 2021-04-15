using Jewellery.Store.ViewModels.Models.Enums;

namespace Jewellery.Store.Services.PriceCalculatorHelpers
{
    public class AbstractPriceCreateArg
    {
        public UserTypeEnum UserType { get; set; }

        public IPriceCalculatorService PriceCalculatorService { get; set; }
    }
}
