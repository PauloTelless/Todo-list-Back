using ApiTodoListBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ApiTodoListBack.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base (options) { }

    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<TarefaCompleta> TarefasComplete { get; set; }  

}
