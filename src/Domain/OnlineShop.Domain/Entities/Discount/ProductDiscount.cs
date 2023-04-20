using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Cart;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Discount
{
    public class ProductDiscount : Entity<long>
    {
        public long DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
        public ProductDiscountCreateType CreateType { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }

    public enum ProductDiscountCreateType : short
    {
        [Display(Name ="توسط سیستم")]
        Systematic,

        [Display(Name = "توسط فروشنده")]
        Seller,
    }
}
