using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Infrastructure.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Addresses).HasForeignKey(x => x.UserId).IsRequired();
            builder.HasOne(v=> v.City).WithMany(v=> v.Addresses).HasForeignKey(x => x.CityId).IsRequired();
        }
    }
}
