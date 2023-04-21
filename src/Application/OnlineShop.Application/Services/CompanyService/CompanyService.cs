using OnlineShop.Application.Core.Services.CompanyService;
using OnlineShop.Application.Core.Services.CompanyService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.CompanyService
{
    public class CompanyService : ApplicationService<int, Company, CompanyInputDto, CompanyUpdateDto, CompanyOutputDto>, ICompanyService
    {
        public CompanyService(IMapping mapping, IRepository<Company, int> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
