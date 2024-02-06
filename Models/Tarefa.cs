namespace ApiTodoListBack.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public bool IsCompleted { get; set; } = false;
}
