using Jewellery.Store.DAL.Entity;

namespace Jewellery.Store.Services
{
    public interface ILoginService
    {
        UserEntity LoginAsync(CredentialsViewModel credentials);
        UserEntity GetUserInfo(int userid);
    }
}