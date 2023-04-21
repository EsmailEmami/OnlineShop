namespace OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos
{
    public class ProductDetailKeyValueInputDto
    {
        public int ProductDetailKeyId { get; set; }
        public Guid ProductId { get; set; }
        public string Value { get; set; }
    }
}
