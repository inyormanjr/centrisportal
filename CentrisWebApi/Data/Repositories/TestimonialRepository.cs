using System.Collections.Generic;
using System.Threading.Tasks;
using CentrisWebApi.Data.IRepositories;
using CentrisWebApi.helpers;
using CentrisWebApi.models.Testimonials;

namespace CentrisWebApi.Data.Repositories
{
    public class TestimonialRepository : ITestimonialsRepository
    {
        public TestimonialRepository(CentrisDataContext context)
        {
            _Context = context;
        }

        public CentrisDataContext _Context { get; }

        public void Add(Testimonial entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Testimonial entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<PageList<Testimonial>> GetAll(UserParams userParams)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Testimonial>> GetByParameters(int skip, int take, string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Testimonial>> GetByRange(int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}