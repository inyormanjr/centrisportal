using CentrisWebApi.models.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrisWebApi.Data.Mappings
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.HasMany(x=> x.Testimonials)
            .WithOne(x=> x.User)
            .HasForeignKey(x=> x.UserId);
        }
    }
}