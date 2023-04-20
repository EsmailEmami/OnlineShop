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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=> x.Cart).WithMany(x=> x.CartItems).HasForeignKey(x=>x.CartId).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.CartItems).HasForeignKey(x => x.ProductId).IsRequired();
            builder.HasOne(x => x.Discount).WithMany(x => x.CartItems).HasForeignKey(x => x.DiscountId);
            builder.Property(x => x.TrackingCode).HasMaxLength(20).IsRequired();
        }
    }
}
