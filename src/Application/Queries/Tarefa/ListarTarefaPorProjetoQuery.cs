using MediatR;
using Application.ViewModel.Tarefas;

namespace Application.Queries.Tarefa;

public class ListarTarefaPorProjetoQuery : IRequest<IEnumerable<TarefaViewModel>>
{
    public Guid ProjetoId { get; set; }
}
