using System.Collections.Generic;
using System.Threading.Tasks;
using CentrisWebApi.helpers;

namespace CentrisWebApi.Data.IRepositories
{
    public interface ICentrisRepository<T> where T : class
    {
         void Add(T entity);
         void Delete(T entity);
         Task<bool> SaveAll();
         Task<PageList<T>> GetAll(UserParams userParams);
         Task<IEnumerable<T>> GetByRange(int skip, int take);
         Task<IEnumerable<T>> GetByParameters(int skip, int take,string search);
    }
}