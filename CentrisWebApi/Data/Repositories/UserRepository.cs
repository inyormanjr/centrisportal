using System.Collections.Generic;
using System.Threading.Tasks;
using CentrisWebApi.Data.IRepositories;
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

        public async Task<IEnumerable<User>> GetAll()
        {
           var user = await _context.Users.Include(x=> x.Photos).AsNoTracking().ToListAsync();
           return user;
        }

        public Task<IEnumerable<User>> GetByParameters(int skip, int take, string search)
        {
          throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetByRange(int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
           var user = await _context.Users.Include(x=> x.Photos).FirstOrDefaultAsync(x=> x.Id == id);
           return user;
        }

        public async Task<bool> SaveAll()
        {
           var ret =   await _context.SaveChangesAsync() > 0;
           return ret;
        }
    }
}