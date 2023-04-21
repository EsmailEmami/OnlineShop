using OnlineShop.Application.Core.Services.SellerService;
using OnlineShop.Application.Core.Services.SellerService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Common.Exceptions;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.User;

namespace OnlineShop.Application.Services.SellerService
{
    public class SellerService : ApplicationService<long, Seller, SellerInputDto, SellerUpdateDto, SellerOutputDto>, ISellerService
    {
        private readonly IRepository<User,long> _userRepository;

        public SellerService(IMapping mapping, IRepository<Seller, long> repository, IUnitOfWork unitOfWork, IRepository<User, long> userRepository) : base(mapping, repository, unitOfWork)
        {
            _userRepository = userRepository;
        }

        public override async Task<long> CreateAsync(SellerInputDto inputDto)
        {
            try
            {
                Seller dbModel = _mapping.Map<SellerInputDto, Seller>(inputDto);
                await _repository.InsertAsync(dbModel);

                User user = _userRepository.Get(inputDto.UserId);
                dbModel.User = user;

                var res = _unitOfWork.SaveAllChanges();
                if (res.Count > 0)
                {
                    throw new BadRequestException(string.Join(",", res));
                }

                return dbModel.Id;
            }
            catch (BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }
    }
}
