using OnlineShop.Application.Core.Services.ProductType;
using OnlineShop.Application.Core.Services.ProductType.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;

namespace OnlineShop.Application.Services.ProductType
{
    public class ProductTypeService : ApplicationService<int, Domain.Entities.Product.ProductType, ProductTypeInputDto, ProductTypeUpdateDto, ProductTypeOutputDto>, IProductTypeService
    {
        public ProductTypeService(IMapping mapping, IRepository<Domain.Entities.Product.ProductType, int> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
