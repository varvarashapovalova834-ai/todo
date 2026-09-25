using System.Data.Common;
using System.Reflection;
using to_do.Data;
using to_do.Interface;
using to_do.Model;
using to_do.Model.Interface;
using to_do.Model.Repositories;
using to_do.Request;
using to_do.Responses;

namespace to_do.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResponse<Todo>> GetAllAsync(int page, int pageSize)
        {
            PagedResponse<Todo> paged = new PagedResponse<Todo>();

            var todos = await _repository.GetAllAsync(page, pageSize);

            var totalCount = todos.Count;

            return new PagedResponse<Todo>
            {
                Items = todos,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };
        }
        public async Task<Todo> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException(
                    $"Product with id {id} not found");
            }

            return product;
        }

        public async Task CreateAsync(CreateTodoRequest request)
        {
            var todo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _repository.AddAsync(todo);

        }

        public async Task UpdateTodoAsync(UpdateTodoRequest request, Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo == null)
            {
                throw new KeyNotFoundException(
                    $"Todo with id {id} not found");
            }

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.IsCompleted = request.IsCompleted;

            await _repository.UpdateTodoAsync(todo);
        }
        
        public async Task UpdateStatusAsync(PatchTodoRequest request, Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo == null)
            {
                throw new KeyNotFoundException(
                    $"Todo with id {id} not found");
            }

            todo.IsCompleted = request.IsCompleted?? false;

            await _repository.UpdateStatusAsync(todo);
        }
        public async Task DeleteAsync(Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo == null)
            {
                throw new KeyNotFoundException(
                    $"Todo with id {id} not found");
            }

            await _repository.DeleteAsync(todo);
        }
    }
}
