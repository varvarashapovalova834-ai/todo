using to_do.Model;
using to_do.Request;
using to_do.Responses;

namespace to_do.Interface
{
    public interface IToDoService
    {
        Task<PagedResponse<Todo>> GetAllAsync(int page, int pageSize);

        Task<Todo> GetByIdAsync(Guid id);

        Task CreateAsync(CreateTodoRequest request);

        Task DeleteAsync(Guid id);

        Task UpdateTodoAsync(UpdateTodoRequest request, Guid id);

        Task UpdateStatusAsync(PatchTodoRequest request, Guid id);
    }
}
