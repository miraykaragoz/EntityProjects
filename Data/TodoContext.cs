using EntityProjects.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityProjects.Data;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
        
    }
}