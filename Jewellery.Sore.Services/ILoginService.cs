using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.Services
{
    public interface ILoginService
    {
        UserViewModel LoginAsync(CredentialsViewModel credentials);
        UserViewModel GetUserInfo(int userid);
    }
}