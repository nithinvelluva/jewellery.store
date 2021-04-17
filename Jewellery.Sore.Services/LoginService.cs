using Jewellery.Store.DAL.Entity;
using Jewellery.Store.DAL.Repository;

namespace Jewellery.Store.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(
        ILoginRepository loginRepository
        )
        {
            _loginRepository = loginRepository;
        }

        public UserEntity LoginAsync(CredentialsViewModel credentials)
        {
            UserEntity user = null;
            if(credentials != null && credentials.UserName != null && credentials.Password != null) 
                user = _loginRepository.LoginAsync(credentials.UserName, credentials.Password);

            return user;
        }

        public UserEntity GetUserInfo(int userid)
        {
           return _loginRepository.GetUserInfo(userid);
        }
    }
}