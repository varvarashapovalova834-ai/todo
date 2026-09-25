using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using to_do.Interface;
using to_do.Model;
using to_do.Request;
using to_do.Responses;
using to_do.Service;

namespace to_do.Controllers

{
    [ApiController]
    [Route("api/todos")]
    public class ProductsController : ControllerBase
    {
        private readonly IToDoService _service;

        public ProductsController(IToDoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<PagedResponse<Todo>> GetAll([FromQuery] int page, [FromQuery]int pageSize)
        {
            var todos = await _service.GetAllAsync(page, pageSize);

            return todos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var todos = await _service.GetByIdAsync(id);

            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoRequest([FromBody] CreateTodoRequest request)
        {
            await _service.CreateAsync(request);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateTodoRequest request)
        {
            await _service.UpdateTodoAsync(request, id);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatusAsync(
            [FromRoute]Guid id, 
            [FromBody] PatchTodoRequest request)
        {
            await _service.UpdateStatusAsync(request, id);

            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

       
    }
}
