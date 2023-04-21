using Microsoft.EntityFrameworkCore.Internal;
using OnlineShop.Common.Dtos;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Core;

namespace OnlineShop.Application.Core
{
    public interface IApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto, SPFInputDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where SPFInputDto : class, ISPFInputDto
        where InputDto : class
        where UpdateDto : class
        where OutputDto : class
    {
        List<IQueryableExtentions.PropertyNameType> PropertyNamesTypesForSpf { get; set; }
        Task<TPrimaryKey> CreateAsync(InputDto inputDto);
        Task UpdateAsync(TPrimaryKey id, UpdateDto inputDto);
        Task<IEnumerable<OutputDto>> GetAllAsync();
        SPFOutPutDto<OutputDto> GetAllWithSPF(SPFInputDto model);
        Task<OutputDto> GetAsync(TPrimaryKey id);
        OutputDto Get(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);

        void RunSPFFilter(ref IQueryable<TEntity> qry, SPFInputDto model);
    }

    public interface IApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto> : IApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto, SPFInputDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where InputDto : class
        where UpdateDto : class
        where OutputDto : class
    {

    }
}
