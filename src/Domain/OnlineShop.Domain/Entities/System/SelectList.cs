using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.System
{
    public class SelectList : Entity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public SelectListType SelectListType { get; set; }


        public virtual ICollection<ProductItem> ProductItemColors { get; set; } = new List<ProductItem>();
    }

    public enum SelectListType : short
    {
        [Display(Name = "رنگ")]
        Color = 0,
    }
}
