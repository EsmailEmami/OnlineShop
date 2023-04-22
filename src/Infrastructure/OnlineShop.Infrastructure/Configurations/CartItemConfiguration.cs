using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Infrastructure.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId).IsRequired();
            builder.HasOne(x => x.ProductItem).WithMany(x => x.CartItems).HasForeignKey(x => x.ProductItemId).IsRequired();

            builder.HasOne(x => x.Seller).WithMany(x => x.CartItems).HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.HasOne(x => x.Discount).WithMany(x => x.CartItems).HasForeignKey(x => x.DiscountId).IsRequired(false);
            builder.Property(x => x.TrackingCode).HasMaxLength(20).IsRequired();

            builder.Ignore(x => x.Sum);
        }
    }
}
