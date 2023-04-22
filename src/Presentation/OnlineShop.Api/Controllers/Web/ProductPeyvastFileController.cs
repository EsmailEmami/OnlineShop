using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core.Services.ProductPeyvastFileService;
using OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Common.Exceptions;
using OnlineShop.Common.Extensions;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductPeyvastFileController : BaseApiController<Guid, ProductPeyvastFile, ProductPeyvastFileInputDto, ProductPeyvastFileUpdateDto, ProductPeyvastFileOutputDto, ProductPeyvastFileSPFInputDto>
    {
        private readonly IMapping _mapping;
        private readonly IRepository<ProductPeyvastFile, Guid> _productPeyvastFileRepository;
        private readonly IRepository<PeyvastFile, Guid> _peyvastFileRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductPeyvastFileController(IProductPeyvastFileService service, IRepository<PeyvastFile, Guid> peyvastFileRepository, IRepository<Product, Guid> productRepository, IRepository<ProductPeyvastFile, Guid> productPeyvastFileRepository, IMapping mapping, IUnitOfWork unitOfWork) : base(service)
        {
            _peyvastFileRepository = peyvastFileRepository;
            _productRepository = productRepository;
            _productPeyvastFileRepository = productPeyvastFileRepository;
            _mapping = mapping;
            _unitOfWork = unitOfWork;
        }

        [NonAction]
        public override Task<ActionResult<Guid>> PostEntity([FromBody] ProductPeyvastFileInputDto model)
        {
            return base.PostEntity(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromForm] IFormFileCollection form,[FromForm] ProductPeyvastFileInputDto model)
        {
            if (form == null || !form.Any())
            {
                throw new BadRequestException("لطفا فایل مورد نظر خود را بفرستید");
            }

            IFormFile file = form[0];
            string fileName = await SaveFile(file, PeyvastFileType.Product);
            PeyvastFile peyvastFile = new(fileName, file.ContentType.ToLower(), file.FileName, PeyvastFileType.Product);
            await _peyvastFileRepository.InsertAsync(peyvastFile);

            model.PeyvastFileId = peyvastFile.Id;

            try
            {
                return await base.PostEntity(model);
            }
            catch
            {
                DeleteFile(Path.Combine(PeyvastFileType.Product.GetFilePath(), fileName));
                throw;
            }
        }

        public override async Task<IActionResult> PutEntity([FromRoute] Guid id, [FromBody] ProductPeyvastFileUpdateDto model)
        {
            ProductPeyvastFile productPeyvastFile = _productPeyvastFileRepository.Get(id);
            string currentFileName = productPeyvastFile.PeyvastFile.FileName;
            string? newfileName = null;

            var files = HttpContext.Request.Form.Files;
            if (files != null && !files.Any())
            {
                IFormFile file = files[0];
                string fileName = await SaveFile(file, PeyvastFileType.Product);
                PeyvastFile peyvastFile = new(fileName, file.ContentType.ToLower(), file.FileName, PeyvastFileType.Product);
                await _peyvastFileRepository.InsertAsync(peyvastFile);
                model.PeyvastFileId = peyvastFile.Id;

                newfileName = fileName;
            }

            _mapping.Map(model, productPeyvastFile);
            try
            {

                await _productPeyvastFileRepository.UpdateAsync(productPeyvastFile).ConfigureAwait(false);
                _unitOfWork.SaveAllChanges();

                // delete last file 
                DeleteFile(Path.Combine(PeyvastFileType.Product.GetFilePath(), currentFileName));

                return OkResult();
            }
            catch
            {
                if (newfileName != null)
                {
                    DeleteFile(Path.Combine(PeyvastFileType.Product.GetFilePath(), newfileName));
                }

                throw;
            }
        }

        public override async Task<IActionResult> DeleteEntity([FromRoute] Guid id)
        {
            ProductPeyvastFile productPeyvastFile = _productPeyvastFileRepository.Get(id);

            _productPeyvastFileRepository.Delete(productPeyvastFile);
            await _unitOfWork.SaveChangesAsync();

            // delete file 
            DeleteFile(Path.Combine(PeyvastFileType.Product.GetFilePath(), productPeyvastFile.PeyvastFile.FileName));

            return OkResult();
        }
    }
}
