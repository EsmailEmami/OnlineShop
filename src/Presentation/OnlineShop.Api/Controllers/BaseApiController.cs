using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core;
using OnlineShop.Common.Dtos;
using OnlineShop.Common.Extensions;
using OnlineShop.Domain.Core;
using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        [NonAction]
        public async Task<string> SaveFile(IFormFile file, string path)
        {
            // validate the file 
            file.ValidateImage();

            var vFileName = file.FileName.ToEnglishNumber();
            vFileName = (vFileName.Length >= 50 ? Path.GetFileNameWithoutExtension(vFileName).Substring(0, vFileName.Length - 50) : Path.GetFileNameWithoutExtension(vFileName)) + Guid.NewGuid().ToString() + Path.GetExtension(vFileName);
            vFileName = vFileName.Replace(" ", "_");

            var vFolderPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            if (!Directory.Exists(vFolderPath)) Directory.CreateDirectory(vFolderPath);

            var vFilePath = Path.Combine(vFolderPath, vFileName);

            using (FileStream fileToSave = new FileStream(vFilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileToSave);
            }

            return vFileName;
        }

        [NonAction]
        public async Task<string> SaveFile(IFormFile file, PeyvastFileType type)
        {
            var path = type.GetFilePath();
            return await SaveFile(file, path);
        }


       [NonAction]
        public string GetPhysicalPathFromVirtual(string path)
        {
            var vFolderPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            if (!Directory.Exists(vFolderPath)) Directory.CreateDirectory(vFolderPath);

            return vFolderPath;
        }

        [NonAction]
        public void DeleteFile(string path)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }
            catch { }
        }
    }

    public abstract class BaseApiController<TPrimaryKey, TEntity, TInputDto, TUpdateDto, TOutputDto, TSPFInputDto> : BaseApiController
        where TEntity : class, IEntity<TPrimaryKey>
        where TSPFInputDto : class, ISPFInputDto
        where TInputDto : class
        where TUpdateDto : class
        where TOutputDto : class
    {
        #region ctor

        protected readonly IApplicationService<TPrimaryKey, TEntity, TInputDto, TUpdateDto, TOutputDto, TSPFInputDto> _service;

        public BaseApiController(IApplicationService<TPrimaryKey, TEntity, TInputDto, TUpdateDto, TOutputDto, TSPFInputDto> service)
        {
            _service = service;
        }

        #endregion

        #region GetList

        [HttpGet]
        public virtual ActionResult<SPFOutPutDto<TOutputDto>> GetList([FromQuery] TSPFInputDto model) => Ok(_service.GetAllWithSPF(model));

        #endregion

        #region Get

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ActionResult<TOutputDto>> GetById([FromRoute] TPrimaryKey id) => Ok(await _service.GetAsync(id));


        #endregion

        #region Post

        [HttpPost]
        public virtual async Task<ActionResult<TPrimaryKey>> PostEntity([FromBody] TInputDto model) => Ok(await _service.CreateAsync(model));

        #endregion

        #region Put

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> PutEntity([FromRoute] TPrimaryKey id, [FromBody] TUpdateDto model)
        {
            await _service.UpdateAsync(id, model);
            return Ok();
        }


        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> DeleteEntity([FromRoute] TPrimaryKey id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

        #endregion
    }

    public abstract class BaseApiController<TPrimaryKey, TEntity, TInputDto, TUpdateDto, TOutputDto> : BaseApiController<TPrimaryKey, TEntity, TInputDto, TUpdateDto, TOutputDto, SPFInputDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TInputDto : class
        where TUpdateDto : class
        where TOutputDto : class
    {
        public BaseApiController(IApplicationService<TPrimaryKey, TEntity, TInputDto, TUpdateDto, TOutputDto, SPFInputDto> service) : base(service)
        {
        }
    }
}
