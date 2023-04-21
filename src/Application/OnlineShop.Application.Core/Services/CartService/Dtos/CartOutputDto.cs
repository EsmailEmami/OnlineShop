using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Core.Services.CartService.Dtos
{
    public class CartOutputDto
    {
        public Guid Id { get; set; }
        public CartState CartState { get; set; }
        public string CartStateName { get; set; }
        public string CreateDate { get; set; }
        public string TrackingCode { get; set; }

        // کد رهگیری مرسوله اداره پست
        public string? PostTrackingCode { get; set; }
        public long UserId { get; set; }
        public decimal Sum { get; set; }
    }
}
