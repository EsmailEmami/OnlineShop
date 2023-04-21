namespace OnlineShop.Application.Core.Services.CartItemService.Dtos
{
    public class CartItemUpdateDto
    {
        public Guid CartId { get; set; }
        public double Quantity { get; set; } = 1;
        public Guid ProductItemId { get; set; }
        public long? DiscountId { get; set; }
    }
}
