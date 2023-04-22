using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Core.Services.ProductService;
using OnlineShop.Application.Core.Services.ProductService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductController : BaseApiController<Guid, Product, ProductInputDto, ProductUpdateDto, ProductOutputDto, ProductSPFInputDto>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService service) : base(service)
        {
            _productService = service;
        }

        [NonAction]
        public override Task<ActionResult<ProductOutputDto>> GetById([FromRoute] Guid id)
        {
            return base.GetById(id);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_productService.GetProductDetail(id));
        }
    }
}
