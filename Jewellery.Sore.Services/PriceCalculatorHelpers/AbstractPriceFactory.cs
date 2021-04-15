using System.Collections.Generic;

namespace Jewellery.Store.Services.PriceCalculatorHelpers
{
    public abstract class  AbstractPriceFactory
    {
        public abstract AbstractPriceCreateResponse Create(AbstractPriceCreateArg arg);
    }
}
