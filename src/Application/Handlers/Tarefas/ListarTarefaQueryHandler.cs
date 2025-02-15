// Application/Handlers/Tarefa/ListarTarefaQueryHandler.cs
using MediatR;
using Application.ViewModel.Tarefas;
using Domain.Interfaces;
using Application.Queries.Tarefa;

namespace Application.Handlers.Tarefa
{
    public class ListarTarefaQueryHandler : IRequestHandler<ListarTarefaQuery, IEnumerable<TarefaViewModel>>
    {
        private readonly ITarefaRepository _repository;

        public ListarTarefaQueryHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TarefaViewModel>> Handle(ListarTarefaQuery request, CancellationToken cancellationToken)
        {
            var tarefas = _repository.ListarTodos();
            var tarefasViewModel = tarefas.Select(t => new TarefaViewModel
            {
                Id = t.Id,
                Nome = t.Nome,
                Status = t.Status
            });

            return Task.FromResult(tarefasViewModel);
        }
    }
}