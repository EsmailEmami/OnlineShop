using OnlineShop.Application.Core.Services.ProductDetailKeyValueService;
using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductDetailKeyValueService
{
    public class ProductDetailKeyValueService : ApplicationService<Guid, ProductDetailKeyValue, ProductDetailKeyValueInputDto, ProductDetailKeyValueUpdateDto, ProductDetailKeyValueOutputDto>, IProductDetailKeyValueService
    {
        public ProductDetailKeyValueService(IMapping mapping, IRepository<ProductDetailKeyValue, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
