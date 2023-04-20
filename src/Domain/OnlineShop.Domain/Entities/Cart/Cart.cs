using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Cart
{
    //TODO(@esmailemami): think abount how to struct a shopping cost
    public class Cart : Entity
    {
        public CartState CartState { get; set; }

        public string TrackingCode { get; set; }

        // کد رهگیری مرسوله اداره پست
        public string PostTrackingCode { get; set; }

        public long UserId { get; set; }
        public virtual User.User User { get; set; }

        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

    public enum CartState : short
    {
        [Display(Name ="باز")]
        Open,
        [Display(Name = "رد شده")]
        Reject,
        [Display(Name = "در انتظار پرداخت")]
        Appect,
        [Display(Name = "پرداخت شده")]
        Payed,
        [Display(Name = "ارسال شده")]
        Sent,
        [Display(Name = "تحویل داده شده")]
        Received,
    }
}
