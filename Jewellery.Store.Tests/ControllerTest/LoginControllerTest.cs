using Jewellery.Store.Controllers;
using Jewellery.Store.DAL.Entity;
using Jewellery.Store.Services;
using Jewellery.Store.ViewModels.Mapper;
using Jewellery.Store.ViewModels.Models;
using Jewellery.Store.ViewModels.Models.Enums;
using Moq;
using Xunit;

namespace Jewellery.Store.Tests.ServicesTest
{
    public class LoginControllerTest
    {
        public Mock<ILoginService> serviceMock = new Mock<ILoginService>();
        public Mock<IUserMapper> mapperMock = new Mock<IUserMapper>();

        [Fact]
        public void Test_Empty_Credentials()
        {
            var credentials = new CredentialsViewModel();
            UserEntity userDTO = null;
            UserViewModel userViewModel = null;

            serviceMock.Setup(p => p.LoginAsync(credentials)).Returns(userDTO);
            mapperMock.Setup(p => p.Encode(userDTO)).Returns(userViewModel);

            LoginController controller = new LoginController(serviceMock.Object, mapperMock.Object);
            var result = controller.Post(credentials);

            Assert.Null(result);
        }        

        [Fact]
        public void Test_Invalid_Credentials()
        {
            var credentials = new CredentialsViewModel
            {
                UserName = "invalid_username",
                Password = "invalid_password"
            };
            UserEntity userDTO = null;
            UserViewModel userViewModel = null;

            serviceMock.Setup(p => p.LoginAsync(credentials)).Returns(userDTO);
            mapperMock.Setup(p => p.Encode(userDTO)).Returns(userViewModel);

            LoginController controller = new LoginController(serviceMock.Object, mapperMock.Object);
            var result = controller.Post(credentials);

            Assert.Null(result);
        }

        [Fact]
        public void Test_Valid_Credentials()
        {
            var credentials = new CredentialsViewModel
            {
                UserName = "user1",
                Password = "password"
            };

            var userDTO = new UserEntity
            {
                id = 1,
                first_name = "Normal",
                last_name = "User",
                usertype = (long)UserTypeEnum.NormalUser,
                user_name = "user1",
                password = "password"
            };
            var userViewModel = new UserViewModel
            {
                Id = userDTO.id,
                FirstName = userDTO.first_name,
                LastName = userDTO.last_name,
                UserTypeId = userDTO.usertype                
            };

            serviceMock.Setup(p => p.LoginAsync(credentials)).Returns(userDTO);
            mapperMock.Setup(p => p.Encode(userDTO)).Returns(userViewModel);

            LoginController controller = new LoginController(serviceMock.Object, mapperMock.Object);
            var result = controller.Post(credentials);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetUserInfo_ReturnsData()
        {
            var userid = 1;

            var userDTO = new UserEntity
            {
                id = 1,
                first_name = "Normal",
                last_name = "User",
                usertype = (long)UserTypeEnum.NormalUser,

                UserType = new UserTypeEntity
                {
                    type = "NORMAL USER",
                    Discount = new DiscountEntity
                    {
                        discount = null
                    }
                }
            };
            var userViewModel = new UserViewModel
            {
                Id = userDTO.id,
                FirstName = userDTO.first_name,
                LastName = userDTO.last_name,
                UserTypeId = userDTO.usertype,
                UserType = new UserTypeViewModel
                {
                    Id = userDTO?.id ?? 0,
                    Type = userDTO?.UserType?.type
                },
                Discount = new DiscountViewModel
                {
                    Id = userDTO?.UserType?.Discount.id ?? 0,
                    Discount = userDTO?.UserType?.Discount?.discount
                }
            };

            serviceMock.Setup(p => p.GetUserInfo(userid)).Returns(userDTO);
            mapperMock.Setup(p => p.Encode(userDTO)).Returns(userViewModel);

            LoginController controller = new LoginController(serviceMock.Object, mapperMock.Object);
            var result = controller.Get(userid);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetUserInfo_ReturnsNoData()
        {
            var userid = -1;
            UserEntity userDTO = null;
            UserViewModel userViewModel = null;

            serviceMock.Setup(p => p.GetUserInfo(userid)).Returns(userDTO);
            mapperMock.Setup(p => p.Encode(userDTO)).Returns(userViewModel);

            LoginController controller = new LoginController(serviceMock.Object, mapperMock.Object);
            var result = controller.Get(userid);
            Assert.Null(result);
        }
    }
}