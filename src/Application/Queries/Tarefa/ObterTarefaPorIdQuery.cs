using MediatR;
using Application.ViewModel.Tarefas;

namespace Application.Queries.Tarefa;

public class ObterTarefaPorIdQuery : IRequest<TarefaViewModel>
{
    public Guid Id { get; set; }
}
