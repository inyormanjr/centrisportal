using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrisWebApi.Data.IRepositories;
using CentrisWebApi.helpers;
using CentrisWebApi.models.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace CentrisWebApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CentrisDataContext _context;
        public UserRepository(CentrisDataContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
           _context.Add(entity);
        }

        public void Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        public  void DeletePhoto(Photo photo)
        {
           _context.Photos.Remove(photo);
        }

        public async Task<PageList<User>> GetAll(UserParams userParams)
        {
            
           var users =  _context.Users.Include(x=> x.Photos).AsQueryable();
           if(!string.IsNullOrEmpty(userParams.SearchName))
           {
               var searchedString = userParams.SearchName.ToLower();
           users = users.Where(x => x.LastName.ToLower().Contains(searchedString) || 
                               x.MiddleName.ToLower().Contains(searchedString)    ||
                               x.FirstName.ToLower().Contains(searchedString));  
           }
           return await PageList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public Task<IEnumerable<User>> GetByParameters(int skip, int take, string search)
        {
          throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetByRange(int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
           var photo = await _context.Photos.Where(x=> x.UserId == userId).FirstOrDefaultAsync(x=> x.IsMain);
           return photo;
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(y=> y.Id == id);
            return photo;
        }

        public async Task<User> GetUserById(int id)
        {
           var user = await _context.Users.Include(x=> x.Photos).Include(x=> x.Testimonials)
                                                                .ThenInclude(x=> x.TestimonyBy)
                                                                .ThenInclude(x=> x.Photos)
                                                                .FirstOrDefaultAsync(x=> x.Id == id);
           return user;
        }

        public async Task<bool> SaveAll()
        {
           var ret =   await _context.SaveChangesAsync() > 0;
           return ret;
        }
    }
}