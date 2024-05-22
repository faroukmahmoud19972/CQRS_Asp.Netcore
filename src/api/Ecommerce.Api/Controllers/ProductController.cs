using Ecommerce.Application.DTOs.EntitiesDTO.Product;
using Ecommerce.Application.Features.Products.Requests.Command;
using Ecommerce.Application.Features.Products.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all_prodcuts")]
        public async Task<IActionResult> get()
        {
            var Categories = await _mediator.Send(new GetAllProductsRequest());
            return Ok(Categories);
        }
        [HttpGet("get-prodcut-by-id/{id}")]
        public async Task<IActionResult> get(int id)
        {
            var catergory = await _mediator.Send(new GetProductDetailsRequest { id = id });
            return Ok(catergory);

        }
        [HttpPost("add-new-prodcut")]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            var command = new CreateProductCommand { ProductDTO = productDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("update-current-category/{id})")]
        public async Task<IActionResult> put([FromBody] ProductDTO productDTO)
        {
            var command = new UpdateProductCommand { ProductDTO = productDTO };
            await _mediator.Send(command);
            return NoContent();


        }

        [HttpDelete("delete-product-by-id/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var command = new DeleteProductCommand { id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
