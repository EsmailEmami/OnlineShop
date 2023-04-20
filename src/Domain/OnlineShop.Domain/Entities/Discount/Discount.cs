using OnlineShop.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Discount
{
    public class Discount : Entity<long>
    {
        public string DiscountCode { get; set; }
        public decimal Value { get; set; }
        public bool UsableCount { get; set; }
        public DiscountType DiscountType { get; set; }

        public virtual ICollection<DiscountUser> DiscountUsers { get; set; } = new List<DiscountUser>();
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; } = new List<ProductDiscount>();
    }

    public enum DiscountType : short
    {
        [Display(Name = "قیمت")]
        Price,
        [Display(Name = "درصد")]
        Percent
    }
}
