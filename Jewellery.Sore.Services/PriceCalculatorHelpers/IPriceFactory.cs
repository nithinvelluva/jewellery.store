namespace Jewellery.Store.Services.PriceCalculatorHelpers
{
    public interface IPriceFactory
    {
        AbstractPriceCreateResponse Create(AbstractPriceCreateArg arg);
    }
}
