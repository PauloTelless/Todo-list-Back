using ApiTodoListBack.Context;
using ApiTodoListBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTodoListBack.Controllers;

[Route("api-todolist1.netlify.app")]
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
    public ActionResult<IEnumerable<TarefaCompleta>> GetAllTaskComplete()
    {
        var tasksComplete = _context.TarefasComplete.ToList();

        return tasksComplete;
    }
    
    [HttpPost("complete")]
    public ActionResult<TarefaCompleta> PostTaskComplete(TarefaCompleta tarefa)
    {
        _context.TarefasComplete.Add(tarefa);

        _context.SaveChanges();

        return tarefa;
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

        if (tarefa == null)
        {
           return NotFound(id);
        }

        _context.Tarefas.Remove(tarefa);

        _context.SaveChanges();

        return tarefa;
    }
    
    [HttpDelete("complete/{id:int}")]
    public ActionResult<TarefaCompleta> DeleteTsakComplete(int id)
    {
       
        var tarefa = _context.TarefasComplete.FirstOrDefault(x => x.TarefaCompleteId == id);

        if (tarefa == null)
        {
           return NotFound(id);
        }

        _context.TarefasComplete.Remove(tarefa);

        _context.SaveChanges();

        return tarefa;
    }
    

}
