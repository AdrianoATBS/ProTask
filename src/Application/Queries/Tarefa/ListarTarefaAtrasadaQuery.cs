using System;
using Application.ViewModel.Tarefas;
using MediatR;

namespace Application.Queries.Tarefa;

public class ListarTarefaAtrasadaQuery : IRequest<IEnumerable<TarefaViewModel>>
{

}
