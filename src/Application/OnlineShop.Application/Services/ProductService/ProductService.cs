using OnlineShop.Application.Core.Services.ProductService;
using OnlineShop.Application.Core.Services.ProductService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductService
{
    public class ProductService : ApplicationService<Guid, Product, ProductInputDto, ProductUpdateDto, ProductOutputDto, ProductSPFInputDto>, IProductService
    {
        public ProductService(IMapping mapping, IRepository<Product, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }

        public ProductDetailOutputDto GetProductDetail(Guid productId)
        {
            var product = _repository.Get(productId);
            return _mapping.Map<Product, ProductDetailOutputDto>(product);
        }

        public override void RunSPFFilter(ref IQueryable<Product> qry, ProductSPFInputDto model)
        {
            if (model.ProductTyepId.HasValue)
            {
                qry = qry.Where(x => x.ProductTypeId == model.ProductTyepId);
            }

            if (model.CompanyId.HasValue)
            {
                qry = qry.Where(x => x.CompanyId == model.CompanyId);
            }

            if (model.SellerId.HasValue)
            {
                qry = qry.Where(x => x.Items.Any(v => v.Sellers.Any(s => s.SellerId == model.SellerId)));
            }

            //TODO: category and child categoty

            if (model.MinPrice.HasValue)
            {
                qry = qry.Where(x => x.Items.Any(v => v.Price >= model.MinPrice.Value));
            }

            if (model.MaxPrice.HasValue)
            {
                qry = qry.Where(x => x.Items.Any(v => v.Price <= model.MaxPrice.Value));
            }

            if (model.HasItems)
                qry = qry.Where(x => x.Items.Any());

            base.RunSPFFilter(ref qry, model);
        }
    }
}
