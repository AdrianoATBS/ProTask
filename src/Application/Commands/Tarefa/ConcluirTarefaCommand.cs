using MediatR;
using System;

namespace Application.Commands.Tarefa;

public class ConcluirTarefaCommand : IRequest<Unit>
{
    public Guid TarefaId { get; set; }
}
