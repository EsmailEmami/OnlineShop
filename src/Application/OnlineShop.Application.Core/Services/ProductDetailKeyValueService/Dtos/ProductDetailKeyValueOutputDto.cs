namespace OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos
{
    public class ProductDetailKeyValueOutputDto
    {
        public int Id { get; set; }
        public int ProductDetailKeyId { get; set; }
        public string Key { get; set; }
        public Guid ProductId { get; set; }
        public string Value { get; set; }
    }
}
