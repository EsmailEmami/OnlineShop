using OnlineShop.Application.Core.Services.CompanyService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.CompanyService
{
    public interface ICompanyService : IApplicationService<int, Company, CompanyInputDto, CompanyUpdateDto, CompanyOutputDto>
    {
    }
}
