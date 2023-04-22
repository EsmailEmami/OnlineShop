using OnlineShop.Application.Core.Services.AddressService;
using OnlineShop.Application.Core.Services.AddressService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Services.AddressService
{
    public class AddressService : ApplicationService<Guid, Address, AddressInputDto, AddressUpdateDto, AddressOutputDto, AddressSPFInputDto>, IAddressService
    {
        public AddressService(IMapping mapping, IRepository<Address, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
        public override void RunSPFFilter(ref IQueryable<Address> qry, AddressSPFInputDto model)
        {
            qry = qry.Where(x => x.UserId == model.UserId);

            base.RunSPFFilter(ref qry, model);
        }
    }
}
