using API.Services;
using Application.Specifications;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery] ParamsSpecification paramsSpec)
        {
            return Ok(await _productService.GetProductsAsync(paramsSpec));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            return Ok(await _productService.GetProductWithSpecAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductToCreateDto ProductToCreate)
        {
            var result = await _productService.CreateProductAsync(ProductToCreate);
            return CreatedAtAction(nameof(GetProduct), new { id = result.Id }, result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm] ProductToUpdateDto ProductToUpdate)
        {
            await _productService.UpdateProductAsync(id, ProductToUpdate);
            return Ok(ProductToUpdate);
        }

        [HttpGet("topologies")]
        public async Task<ActionResult<IReadOnlyList<ProductTopologyToReturnDto>>> GetTopologies()
        {
            return Ok(await _productService.GetAllTopologies());
        }

        [HttpGet("functions")]
        public async Task<ActionResult<IReadOnlyList<ProductFunctionToReturnDto>>> GetFunctions()
        {
            return Ok(await _productService.GetAllFunctions());
        }
    }
}