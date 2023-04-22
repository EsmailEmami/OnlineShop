using OnlineShop.Application.Core;
using OnlineShop.Application.Mapping;
using OnlineShop.Common.Dtos;
using OnlineShop.Common.Exceptions;
using OnlineShop.Common.Extensions;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Core;

namespace OnlineShop.Application
{
    public abstract class ApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto, SPFInputDto> : IApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto, SPFInputDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where SPFInputDto : class, ISPFInputDto
        where InputDto : class
        where UpdateDto : class
        where OutputDto : class
    {
        protected readonly IMapping _mapping;
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public List<IQueryableExtentions.PropertyNameType> PropertyNamesTypesForSpf { get; set; }

        public ApplicationService(IMapping mapping,
                                  IRepository<TEntity, TPrimaryKey> repository,
                                  IUnitOfWork unitOfWork)
        {
            _mapping = mapping;
            _repository = repository;
            _unitOfWork = unitOfWork;

            PropertyNamesTypesForSpf = new List<IQueryableExtentions.PropertyNameType>();
        }

        public virtual async Task<TPrimaryKey> CreateAsync(InputDto inputDto)
        {
            try
            {
                TEntity dbModel = _mapping.Map<InputDto, TEntity>(inputDto);
                await _repository.InsertAsync(dbModel);

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
                throw new DatabaseException(ex);
            }
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            var dbModel = await _repository.GetAsync(id);
            if (dbModel == null || dbModel.Deleted)
            {
                throw new EntityNotFoundException();
            }

            dbModel.Deleted = true;

            try
            {
                await _repository.UpdateAsync(dbModel).ConfigureAwait(false);
                var res = _unitOfWork.SaveAllChanges();
                if (res.Count > 0)
                {
                    throw new BadRequestException("خطا در حذف داده های ورودی");
                }
            }
            catch (BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
        }

        public virtual async Task<OutputDto> GetAsync(TPrimaryKey id)
        {
            var dbModel = await _repository.GetAsync(id);
            if (dbModel == null || dbModel.Deleted)
                throw new EntityNotFoundException();

            return _mapping.Map<TEntity, OutputDto>(dbModel);
        }

        public virtual OutputDto Get(TPrimaryKey id)
        {
            var dbModel = _repository.Get(id);
            if (dbModel?.Deleted != false)
                throw new EntityNotFoundException();

            return _mapping.Map<TEntity, OutputDto>(dbModel);
        }

        public virtual async Task<IEnumerable<OutputDto>> GetAllAsync()
        {
            var dbResult = await _repository.GetAllListAsync();
            return _mapping.Map<TEntity, IEnumerable<OutputDto>>(dbResult.Where(x => !x.Deleted));
        }

        public virtual SPFOutPutDto<OutputDto> GetAllWithSPF(SPFInputDto model)
        {
            if (model == null)
                model = Activator.CreateInstance<SPFInputDto>();

            var dbResult = _repository.GetAll().Where(x => !x.Deleted);

            List<OutputDto> res;
            long totalRecord = 0;

            RunSPFFilter(ref dbResult, model);

            if (this.PropertyNamesTypesForSpf != null && this.PropertyNamesTypesForSpf.Count > 0)
            {
                dbResult = dbResult.SPF(model, this.PropertyNamesTypesForSpf, out totalRecord);
            }

            res = _mapping.ProjectTo<TEntity, OutputDto>(dbResult).ToList();

            return new SPFOutPutDto<OutputDto>()
            {
                ShowRecord = res.Count(),
                ResultList = res,
                TotalRecord = totalRecord
            };
        }

        public virtual async Task UpdateAsync(TPrimaryKey id, UpdateDto inputDto)
        {
            var dbModel = await _repository.GetAsync(id).ConfigureAwait(false);
            if (dbModel?.Deleted != false)
            {
                throw new EntityNotFoundException();
            }

            _mapping.Map(inputDto, dbModel);

            try
            {

                await _repository.UpdateAsync(dbModel).ConfigureAwait(false);
                var res = _unitOfWork.SaveAllChanges(false);
                if (res.Count > 0)
                {
                    throw new BadRequestException("خطا در ذخیره سازی داده های ورودی");
                }
            }
            catch (BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
        }

        public virtual void RunSPFFilter(ref IQueryable<TEntity> qry, SPFInputDto model) { }
    }

    public abstract class ApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto> : ApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto, SPFInputDto>, IApplicationService<TPrimaryKey, TEntity, InputDto, UpdateDto, OutputDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where InputDto : class
        where UpdateDto : class
        where OutputDto : class
    {
        protected ApplicationService(IMapping mapping, IRepository<TEntity, TPrimaryKey> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}