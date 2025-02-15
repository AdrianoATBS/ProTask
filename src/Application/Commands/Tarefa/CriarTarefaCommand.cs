using MediatR;
using System;

namespace Application.Commands.Tarefa;

public class CriarTarefaCommand : IRequest<Guid>
{ 
    public Guid ProjetoId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataVencimento { get; set; }
}
