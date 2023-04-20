using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Carts).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict).IsRequired();

            builder.HasOne(x => x.Address).WithMany(x => x.Carts).HasForeignKey(x => x.AddressId);

            builder.Property(x => x.TrackingCode).HasMaxLength(20).IsRequired();
        }
    }
}
