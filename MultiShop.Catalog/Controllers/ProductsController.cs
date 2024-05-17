using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _categoryService;

        public ProductsController(IProductService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = _categoryService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var values = _categoryService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _categoryService.CreateProductAsync(createProductDto);
            return Ok("Product Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _categoryService.DeleteProductAsync(id);
            return Ok("Product Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _categoryService.UpdateProductAsync(updateProductDto);
            return Ok("Product Başarıyla Güncellendi");
        }
    }
}
