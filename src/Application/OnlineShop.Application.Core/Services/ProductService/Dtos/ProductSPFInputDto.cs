using OnlineShop.Common.Dtos;

namespace OnlineShop.Application.Core.Services.ProductService.Dtos
{
    public class ProductSPFInputDto : SPFInputDto
    {
        public int? ProductTyepId { get; set; }
        public int? CompanyId { get; set; }
        public long? SellerId { get; set; }
        public int? CategoryId { get; set; }
        public int? ChildCategoryId { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public bool HasItems { get; set; }
    }
}
