using Jewellery.Store.DAL.Entity;
using System.Threading.Tasks;

namespace Jewellery.Store.DAL.Repository
{
    public interface ILoginRepository : IRepository<UserEntity>
    {
        UserEntity LoginAsync(string userName, string password);

        UserEntity GetUserInfo(int userid);
    }
}
