using ApiTodoListBack.Context;
using ApiTodoListBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTodoListBack.Controllers;

[Route("[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly AppDbContext _context;

    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Get()
    {
        var tarefas = _context.Tarefas.ToList();

        return tarefas;
    }

    [HttpPost]
    public ActionResult<Tarefa> Post(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);

        _context.SaveChanges();

        return tarefa;
    }

    [HttpGet("complete")]
    public ActionResult<IEnumerable<Tarefa>> GetCompletes()
    {
        var tarefas = _context.TarefasComplete.ToList();

        return tarefas;
    }

    [HttpPost("complete")]
    public ActionResult<Tarefa> PostTaskComplete(Tarefa tarefa)
    {
        try
        {
            _context.Tarefas.Add(tarefa);

            _context.SaveChanges(); 
            
            return tarefa;
        }
        catch (Exception ex)
        {
            // Log do erro
            Console.WriteLine($"Erro ao completar tarefa: {ex.Message}");
            // Retorne um StatusCode adequado e uma mensagem de erro, por exemplo:
            return StatusCode(500, "Erro interno ao completar a tarefa");
        }
    }



    [HttpPut("complete/{id:int}")]
    public ActionResult<Tarefa> CompleteTask(int id)
    {
        var tarefa = _context.Tarefas.Find(id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.IsCompleted = true;

        _context.SaveChanges();

        return Ok(tarefa);
    }


    [HttpDelete("{id:int}")]
    public ActionResult<Tarefa> Delete(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(x => x.TarefaId == id);

        _context.Tarefas.Remove(tarefa);

        _context.SaveChanges();

        return tarefa;
    }
    
    [HttpDelete("complete/{id:int}")]
    public ActionResult<Tarefa> DeleteTaskComplete(int id)
    {
        var tarefa = _context.TarefasComplete.FirstOrDefault(x => x.TarefaId == id);

        if (id == null)
        {
            _context.TarefasComplete.Remove(tarefa);

            _context.SaveChanges();

            return tarefa;
        }

        return tarefa;
    }

}
