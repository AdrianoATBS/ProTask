using MediatR;
using Application.ViewModel.Tarefas;

namespace Application.Queries.Tarefa;

public class ListarTarefaQuery : IRequest<IEnumerable<TarefaViewModel>>
{

}
