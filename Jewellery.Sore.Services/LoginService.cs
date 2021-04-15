using Jewellery.Store.DAL.Repository;
using Jewellery.Store.ViewModels.Mapper;
using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserMapper _userMapper;
        private readonly ILoginRepository _loginRepository;

        public LoginService(
        IUserMapper userMapper,
        ILoginRepository loginRepository
        )
        {
            _userMapper = userMapper;
            _loginRepository = loginRepository;
        }      

        public UserViewModel LoginAsync(CredentialsViewModel credentials)
        {
            var user = _loginRepository.LoginAsync(credentials.UserName, credentials.Password);
            if(user != null)
                return _userMapper.Encode(user);

            return null;
        }        

        public UserViewModel GetUserInfo(int userid)
        {
            var user = _loginRepository.GetUserInfo(userid);
            return _userMapper.Encode(user);
        }
    }
}