using OnlineShop.Application.Core.Services.ProductService;
using OnlineShop.Application.Core.Services.ProductService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductController : BaseApiController<Guid, Product, ProductInputDto, ProductUpdateDto, ProductOutputDto>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
