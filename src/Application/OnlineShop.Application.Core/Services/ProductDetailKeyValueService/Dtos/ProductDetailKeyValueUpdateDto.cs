namespace OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos
{
    public class ProductDetailKeyValueUpdateDto
    {
        public int ProductDetailKeyId { get; set; }
        public Guid ProductId { get; set; }
        public string Value { get; set; }
    }
}
