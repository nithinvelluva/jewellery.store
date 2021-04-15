namespace Jewellery.Store.ViewModels.Models
{
    public class UserViewModel : BaseViewModel
    {
        public long UserTypeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }        

        public UserTypeViewModel UserType { get; set; }

        public DiscountViewModel Discount { get; set; }
    }
}
