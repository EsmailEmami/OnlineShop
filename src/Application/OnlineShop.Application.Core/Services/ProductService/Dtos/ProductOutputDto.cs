namespace OnlineShop.Application.Core.Services.ProductService.Dtos
{
    public class ProductOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PicPath { get; set; }
        public decimal Price { get; set; }
    }
}
