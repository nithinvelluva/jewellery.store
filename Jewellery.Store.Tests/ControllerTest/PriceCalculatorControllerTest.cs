using Jewellery.Store.Controllers;
using Jewellery.Store.Services;
using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.ViewModels.Models.Enums;
using Moq;
using Xunit;

namespace Jewellery.Store.Tests.ServicesTest
{
    public class PriceCalculatorControllerTest
    {
        public Mock<IPriceCalculatorService> serviceMock = new Mock<IPriceCalculatorService>();

        [Fact]
        public void Test_Empty_PriceRequest()
        {
            var priceRequest = new PriceRequest();
            PriceCalculatorResponse priceResponse = null;

            serviceMock.Setup(p => p.CalculatePrice(priceRequest)).Returns(priceResponse);

            PriceCalculatorController controller = new PriceCalculatorController(serviceMock.Object);
            var result = controller.Post(priceRequest);

            Assert.Null(result);
        }

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

            serviceMock.Setup(p => p.CalculatePrice(priceRequest)).Returns(priceResponse);

            PriceCalculatorController controller = new PriceCalculatorController(serviceMock.Object);
            var result = controller.Post(priceRequest);

            Assert.NotNull(result);
            Assert.Null(result.Discount);
            Assert.True(result.TotalPrice == priceResponse.TotalPrice);
        }

        [Fact]
        public void Test_CalculatePrice_ReturnsWithDiscount()
        {
            var priceRequest = new PriceRequest
            {
                UserType = (long)UserTypeEnum.PrivilegedUser,
                GoldPrice = 10,
                Weight = 5
            };
            var priceResponse = new PriceCalculatorResponse
            {
                GoldPrice = priceRequest.GoldPrice,
                Weight = priceRequest.Weight,
                TotalPrice = (priceRequest.GoldPrice * priceRequest.Weight)- (((priceRequest.GoldPrice * priceRequest.Weight) * 2) / 100),
                Discount = 2
            };

            serviceMock.Setup(p => p.CalculatePrice(priceRequest)).Returns(priceResponse);

            PriceCalculatorController controller = new PriceCalculatorController(serviceMock.Object);
            var result = controller.Post(priceRequest);

            Assert.NotNull(result);
            Assert.NotNull(result.Discount);
            Assert.True(result.TotalPrice == priceResponse.TotalPrice);
        }
    }
}