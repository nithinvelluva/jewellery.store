
namespace Jewellery.Store.ViewModels.Models
{
    public class PriceCalculatorResponse
    {
        public decimal? GoldPrice { get; set; }
        public decimal? Weight { get; set; }

        public decimal? TotalPrice { get; set; }

        public long? Discount { get; set; }
    }
}
