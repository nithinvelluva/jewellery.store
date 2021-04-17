using Jewellery.Store.DAL.Repository;
using Jewellery.Store.Services;
using Jewellery.Store.Services.PriceCalculatorHelpers;
using Jewellery.Store.Services.PriceCalculatorHelpers.Products;
using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.ViewModels.Models.Enums;
using Moq;
using Xunit;

namespace Jewellery.Store.Tests.ServicesTest
{
    public class PriceCalculatorServiceTest
    {
        public Mock<IPriceCalculatorRepository> repositoryMock = new Mock<IPriceCalculatorRepository>();
        public Mock<IPriceFactory> factoryMock = new Mock<IPriceFactory>();

        [Fact]
        public void Test_CalculatePrice_ReturnsWithoutDiscount()
        {
            var priceRequest = new PriceRequest
            {
                UserType = (long)UserTypeEnum.NormalUser,
                GoldPrice = 10,
                Weight = 5
            };
            var priceResponse = new PriceCalculatorResponse
            {
                GoldPrice = priceRequest.GoldPrice,
                Weight = priceRequest.Weight,
                TotalPrice = priceRequest.GoldPrice * priceRequest.Weight,
                Discount = null
            };

            PriceCalculatorService service = new PriceCalculatorService(repositoryMock.Object, factoryMock.Object);
            var arg = new AbstractPriceCreateArg
            {
                UserType = (UserTypeEnum)priceRequest.UserType,
                PriceCalculatorService = service
            };
            var product = new AbstractPriceCreateResponse
            {
                Product = new NormalPriceProduct(service)
            };

            factoryMock.Setup(p => p.Create(arg)).Returns(product);
            var result = product.Product.CalculatePrice(priceRequest);

            Assert.NotNull(result);
            Assert.Null(result.Discount);
            Assert.True(result.TotalPrice == priceResponse.TotalPrice);
        }

        [Fact]
        public void Test_CalculatePrice_ReturnsWitDiscount()
        {
            var priceRequest = new PriceRequest
            {
                UserType = (long)UserTypeEnum.PrivilegedUser,
                GoldPrice = 10,
                Weight = 5
            };
            var discount = 2;
            var priceResponse = new PriceCalculatorResponse
            {
                GoldPrice = priceRequest.GoldPrice,
                Weight = priceRequest.Weight,
                TotalPrice = (priceRequest.GoldPrice * priceRequest.Weight) - (((priceRequest.GoldPrice * priceRequest.Weight) * discount) / 100),
                Discount = discount
            };

            PriceCalculatorService service = new PriceCalculatorService(repositoryMock.Object, factoryMock.Object);
            var arg = new AbstractPriceCreateArg
            {
                UserType = (UserTypeEnum)priceRequest.UserType,
                PriceCalculatorService = service
            };
            var product = new AbstractPriceCreateResponse
            {
                Product = new PrivilegedPriceProduct(service)
            };

            factoryMock.Setup(p => p.Create(arg)).Returns(product);
            repositoryMock.Setup(p => p.GetDiscount(priceRequest.UserType)).Returns(discount);
            var result = product.Product.CalculatePrice(priceRequest);

            Assert.NotNull(result);
            Assert.NotNull(result.Discount);
            Assert.True(result.TotalPrice == priceResponse.TotalPrice);
        }

        [Fact]
        public void Test_PriceFactory_ReturnsPrivilegedPriceProduct()
        {
            var priceRequest = new PriceRequest
            {
                UserType = (long)UserTypeEnum.NormalUser
            };           

            PriceCalculatorFactory factory = new PriceCalculatorFactory();
            var arg = new AbstractPriceCreateArg
            {
                UserType = (UserTypeEnum)priceRequest.UserType
            };
            var product = new AbstractPriceCreateResponse
            {
                Product = new NormalPriceProduct(null)
            };

            factoryMock.Setup(p => p.Create(arg)).Returns(product);
            var result = factory.Create(arg);

            Assert.NotNull(result.Product);
            Assert.True(result.Product.GetType() == typeof(NormalPriceProduct));
        }

        [Fact]
        public void Test_PriceFactory_ReturnsNormalPriceProduct()
        {
            var priceRequest = new PriceRequest
            {
                UserType = (long)UserTypeEnum.PrivilegedUser
            };

            PriceCalculatorFactory factory = new PriceCalculatorFactory();
            var arg = new AbstractPriceCreateArg
            {
                UserType = (UserTypeEnum)priceRequest.UserType
            };
            var product = new AbstractPriceCreateResponse
            {
                Product = new PrivilegedPriceProduct(null)
            };

            factoryMock.Setup(p => p.Create(arg)).Returns(product);
            var result = factory.Create(arg);

            Assert.NotNull(result.Product);
            Assert.True(result.Product.GetType() == typeof(PrivilegedPriceProduct));
        }
    }
}