using System;

namespace Application.ViewModel.Tarefas;

public class TarefaViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Status { get; set; }
    public DateTime DataVencimento { get; set; }
    public Guid ProjetoId { get; set; }
    
}
