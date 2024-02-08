using System.ComponentModel.DataAnnotations;

namespace ApiTodoListBack.Models;

public class TarefaCompleta
{
    [Key]
    public int TarefaCompleteId { get; set; }
    public string? Name { get; set; }
    public string? Discription { get; set; }
    public bool IsCompleted { get; set; } = true;
}
