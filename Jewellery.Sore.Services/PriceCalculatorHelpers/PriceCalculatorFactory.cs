using Jewellery.Store.Services.PriceCalculatorHelpers.Products;
using Jewellery.Store.ViewModels.Models.Enums;
using System;
using System.Collections.Generic;

namespace Jewellery.Store.Services.PriceCalculatorHelpers
{
    public abstract class PriceCalculatorFactory : AbstractPriceFactory, IPriceFactory
    {
        private IDictionary<UserTypeEnum, Type> _userTypeDictionary;
        public PriceCalculatorFactory()
        {
            _userTypeDictionary = GetUserTypeDictionary();
        }

        public Dictionary<UserTypeEnum, Type> GetUserTypeDictionary()
        {
            return new Dictionary<UserTypeEnum, Type>
            {
                {UserTypeEnum.NormalUser, typeof(NormalPriceProduct)},
                {UserTypeEnum.PrivilegedUser, typeof(PrivilegedPriceProduct)}
            };
        }

        public override AbstractPriceCreateResponse Create(AbstractPriceCreateArg arg)
        {
            Type type;
            if (!_userTypeDictionary.TryGetValue(arg.UserType, out type))
                return null;

            return new AbstractPriceCreateResponse
            {
                Product = (PriceProduct)Activator.CreateInstance(type)
            };
        }
    }
}
