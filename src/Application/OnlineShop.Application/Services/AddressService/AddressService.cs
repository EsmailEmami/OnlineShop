using OnlineShop.Application.Core.Services.AddressService;
using OnlineShop.Application.Core.Services.AddressService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;
using OnlineShop.Domain.Identity;

namespace OnlineShop.Application.Services.AddressService
{
    public class AddressService : ApplicationService<Guid, Address, AddressInputDto, AddressUpdateDto, AddressOutputDto, AddressSPFInputDto>, IAddressService
    {
        private readonly IUser _user;
        public AddressService(IMapping mapping, IRepository<Address, Guid> repository, IUnitOfWork unitOfWork, IUser user) : base(mapping, repository, unitOfWork)
        {
            _user = user;
        }

        public override Task<Guid> CreateAsync(AddressInputDto inputDto)
        {
            inputDto.UserId = _user.UserId;
            return base.CreateAsync(inputDto);
        }

        public override void RunSPFFilter(ref IQueryable<Address> qry, AddressSPFInputDto model)
        {
            qry = qry.Where(x => x.UserId == model.UserId);

            base.RunSPFFilter(ref qry, model);
        }
    }
}
