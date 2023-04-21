using OnlineShop.Application.Core.Services.SelectListService.Dtos;

namespace OnlineShop.Application.Core.Services.CartItemService.Dtos
{
    public class CartItemOutputDto
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public double Quantity { get; set; } = 1;
        public string TrackingCode { get; set; }
        public Guid ProductItemId { get; set; }
        public long? DiscountId { get; set; }
        public decimal Sum { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public SelectListOutputDto Color { get; set; }
        public Guid SellerId { get; set; }
        public string StoreName { get; set; }
    }
}
