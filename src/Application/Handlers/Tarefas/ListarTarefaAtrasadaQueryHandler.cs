using MediatR;
using Domain.Interfaces;
using Application.Queries.Tarefa;
using Application.ViewModel.Tarefas; 


namespace Application.Handlers.Tarefa
{
    public class ListarTarefaAtrasadaQueryHandler 
        : IRequestHandler<ListarTarefaAtrasadaQuery, IEnumerable<TarefaViewModel>>
    {
        private readonly ITarefaRepository _repository;

        public ListarTarefaAtrasadaQueryHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TarefaViewModel>> Handle(
            ListarTarefaAtrasadaQuery request, 
            CancellationToken cancellationToken)
        {
            var tarefas = _repository.ListarTarefaAtrasada();
            var viewModels = tarefas.Select(t => new TarefaViewModel
            {
                Id = t.Id,
                Nome = t.Nome,
                Status = t.Status,
                DataVencimento = t.DataDeVencimento,
                ProjetoId = t.ProjetoId
            });

            return Task.FromResult(viewModels);
        }
    }
}