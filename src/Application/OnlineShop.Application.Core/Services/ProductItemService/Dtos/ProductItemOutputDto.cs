using OnlineShop.Application.Core.Services.SelectListService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductItemService.Dtos
{
    public class ProductItemOutputDto
    {
        public Guid Id { get; set; }
        public int ColorId { get; set; }
        public SelectListOutputDto Color { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
