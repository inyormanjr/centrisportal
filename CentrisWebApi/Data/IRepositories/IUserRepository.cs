using System.Threading.Tasks;
using CentrisWebApi.models.UserAgg;

namespace CentrisWebApi.Data.IRepositories
{
    public interface IUserRepository:ICentrisRepository<User>
    {
         Task<User> GetUserById(int id);
    }
}