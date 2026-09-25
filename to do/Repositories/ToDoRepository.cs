using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using to_do.Data;
using to_do.Model.Interface;
using to_do.Request;
using to_do.Responses;
using to_do.Service;

namespace to_do.Model.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _db;

        public ToDoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Todo>> GetAllAsync(int page, int pageSize)
        {
            var items = await _db.Todos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }

        public async Task<Todo?> GetByIdAsync(Guid id)
        {
            return await _db.Todos
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Todo todo)
        {
            todo.CreatedAt = DateTime.UtcNow;

            await _db.Todos.AddAsync(todo);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todo todo)
        {
            _db.Todos.Remove(todo);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            _db.Todos.Update(todo);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync (Todo todo)
        {
            _db.Todos.Update(todo);

            await _db.SaveChangesAsync();
        }

    }
}
