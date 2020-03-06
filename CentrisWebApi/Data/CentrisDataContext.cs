using CentrisWebApi.models.UserProfileAgg;
using Microsoft.EntityFrameworkCore;

namespace CentrisWebApi.Data
{
    public class CentrisDataContext : DbContext
    {
        public CentrisDataContext(DbContextOptions options):base(options)
        {
        
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}