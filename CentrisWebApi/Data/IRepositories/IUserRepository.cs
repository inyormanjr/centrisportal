using System.Threading.Tasks;
using CentrisWebApi.models.UserAgg;

namespace CentrisWebApi.Data.IRepositories
{
    public interface IUserRepository:ICentrisRepository<User>
    {
         Task<User> GetUserById(int id);
         Task<Photo> GetPhotoById(int id);

         Task<Photo> GetMainPhotoForUser(int userId);
         void  DeletePhoto(Photo photo);
    }
}