using OnlineShop.Application.Core.Services.ProductItemSellerService;
using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductItemSellerService
{
    public class ProductItemSellerService : ApplicationService<Guid, ProductItemSeller, ProductItemSellerInputDto, ProductItemSellerUpdateDto, ProductItemSellerOutputDto>, IProductItemSellerService
    {
        public ProductItemSellerService(IMapping mapping, IRepository<ProductItemSeller, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
