using to_do.Request;

namespace to_do.Model.Interface
{
    public interface IToDoRepository
    {
        Task<List<Todo>> GetAllAsync(int page, int pageSize);

        Task<Todo?> GetByIdAsync(Guid id);

        Task AddAsync(Todo todo);

        Task DeleteAsync(Todo todo);

        Task UpdateTodoAsync(Todo todo);

        Task UpdateStatusAsync(Todo todo);
    }
}
