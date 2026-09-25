using Microsoft.EntityFrameworkCore;
using to_do.Model;

namespace to_do.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}