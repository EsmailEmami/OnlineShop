namespace OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos
{
    public class ProductItemSellerInputDto
    {
        public Guid ProductItemId { get; set; }
        public long SellerId { get; set; }
        public double Quantity { get; set; }
        public bool IsActive { get; set; }

    }
}
