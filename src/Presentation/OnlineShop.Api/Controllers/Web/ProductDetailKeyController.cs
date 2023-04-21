using OnlineShop.Application.Core.Services.ProductDetailKeyService;
using OnlineShop.Application.Core.Services.ProductDetailKeyService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductDetailKeyController : BaseApiController<int, ProductDetailKey, ProductDetailKeyInputDto, ProductDetailKeyUpdateDto, ProductDetailKeyOutputDto>
    {
        public ProductDetailKeyController(IProductDetailKeyService service) : base(service)
        {
        }
    }
}
