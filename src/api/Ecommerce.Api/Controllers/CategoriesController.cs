using Ecommerce.Application.DTOs.EntitiesDTO.Category;
using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Features.Categories.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all_categories")]
        public async Task<IActionResult> get()
        {
            var Categories = await _mediator.Send(new GetAllCategoriesRequest());
            return Ok(Categories);
        }
        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> get(int id)
        {
            var catergory = await _mediator.Send(new GetCategoryDetailsRequest { id = id });
            return Ok(catergory);

        }
        [HttpPost("add-new-category")]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            var command = new CreateCategoryCommand { CategoryDTO = categoryDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("update-current-category/{id})")]
        public async Task<IActionResult> put([FromBody] CategoryDTO categoryDTO)
        {
            var command = new UpdateCategoryCommand { CategoryDTO = categoryDTO };
            await _mediator.Send(command);
            return NoContent();


        }

        [HttpDelete("delete-category-by-id/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var command = new DeleteCategoryCommand { id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
