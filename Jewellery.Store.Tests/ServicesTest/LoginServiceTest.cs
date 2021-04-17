using Jewellery.Store.DAL.Entity;
using Jewellery.Store.DAL.Repository;
using Jewellery.Store.Services;
using Moq;
using Xunit;

namespace Jewellery.Store.Tests.ServicesTest
{
    public class LoginServiceTest
    {
        public Mock<ILoginRepository> repositoryMock = new Mock<ILoginRepository>();

        [Fact]
        public void Test_Empty_Credentials()
        {
            var credentials = new CredentialsViewModel();
            UserEntity userDTO = null;

            repositoryMock.Setup(p => p.LoginAsync(credentials.UserName, credentials.Password)).Returns(userDTO);

            LoginService loginService = new LoginService(repositoryMock.Object);
            var result = loginService.LoginAsync(credentials);
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

            repositoryMock.Setup(p => p.LoginAsync(credentials.UserName, credentials.Password)).Returns(userDTO);

            LoginService loginService = new LoginService(repositoryMock.Object);
            var result = loginService.LoginAsync(credentials);
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
                usertype = 1,
                user_name = "user1",
                password = "password"
            };

            repositoryMock.Setup(p => p.LoginAsync(credentials.UserName, credentials.Password)).Returns(userDTO);

            LoginService loginService = new LoginService(repositoryMock.Object);
            var result = loginService.LoginAsync(credentials);
            Assert.NotNull(result);
            Assert.True(userDTO.Equals(result));
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
                usertype = 1,

                UserType = new UserTypeEntity
                {
                    type = "NORMAL USER",
                    Discount = new DiscountEntity
                    {
                        discount = null
                    }
                }
            };

            repositoryMock.Setup(p => p.GetUserInfo(userid)).Returns(userDTO);

            LoginService loginService = new LoginService(repositoryMock.Object);
            var result = loginService.GetUserInfo(userid);
            Assert.NotNull(result);
            Assert.True(userDTO.Equals(result));
        }

        [Fact]
        public void Test_GetUserInfo_ReturnsNoData()
        {
            var userid = -1;
            UserEntity userDTO = null;

            repositoryMock.Setup(p => p.GetUserInfo(userid)).Returns(userDTO);

            LoginService loginService = new LoginService(repositoryMock.Object);
            var result = loginService.GetUserInfo(userid);
            Assert.Null(result);
        }
    }
}