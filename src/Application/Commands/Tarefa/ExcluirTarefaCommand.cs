using MediatR;

namespace Application.Commands.Tarefa;

public class ExcluirTarefaCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
