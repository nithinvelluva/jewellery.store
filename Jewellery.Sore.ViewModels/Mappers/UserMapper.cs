using Jewellery.Store.DAL.Entity;
using Jewellery.Store.ViewModels.Models;
using System;

namespace Jewellery.Store.ViewModels.Mapper
{
    public class UserMapper : BaseMapper<UserEntity, UserViewModel>, IUserMapper
    {
        public override UserEntity Decode(UserViewModel data)
        {
            throw new NotImplementedException();
        }

        public override UserViewModel Encode(UserEntity data) =>
        new UserViewModel
        {
            Id = data.id,
            FirstName = data.first_name,
            LastName = data.last_name,
            UserTypeId = data.usertype,

            UserType = new UserTypeViewModel
            {
                Id = data?.id ?? 0,
                Type = data?.UserType?.type
            },

            Discount = new DiscountViewModel
            {
                Id = data?.UserType?.Discount.id ?? 0,
                Discount = data?.UserType?.Discount?.discount
            }
        };
    }

    public interface IUserMapper : IMapper<UserEntity, UserViewModel> { }
}
