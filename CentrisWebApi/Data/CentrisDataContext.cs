using CentrisWebApi.models.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace CentrisWebApi.Data
{
    public class CentrisDataContext : DbContext
    {
        public CentrisDataContext(DbContextOptions options):base(options)
        {
        
        }

        public DbSet<User> Users {get;set;}
        public DbSet<Photo> Photos {get;set;} 
    }
}