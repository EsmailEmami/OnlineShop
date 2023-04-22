using OnlineShop.Application.Core.Services.ProductTypeService;
using OnlineShop.Application.Core.Services.ProductTypeService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductTypeController : BaseApiController<int, ProductType, ProductTypeInputDto, ProductTypeUpdateDto, ProductTypeOutputDto>
    {
        public ProductTypeController(IProductTypeService service) : base(service)
        {
        }
    }
}
