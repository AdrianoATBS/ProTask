using MediatR;
using Application.ViewModel.Projetos;
using Domain.Interfaces;
using Application.Queries.Projetos;

namespace Application.Handlers.Projeto
{
    public class ListarProjetoQueryHandler : IRequestHandler<ListarProjetoQuery, IEnumerable<ProjetoViewModel>>
    {
        private readonly IProjetoRepository _repository;

        public ListarProjetoQueryHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ProjetoViewModel>> Handle(ListarProjetoQuery request, CancellationToken cancellationToken)
        {
            var projetos = _repository.ListarTodos();
            var projetosViewModel = projetos.Select(p => new ProjetoViewModel
            {
                Id = p.HashDeConvite,
                Nome = p.Nome,
                Status = p.Status,
                DataTermino = p.DataDeTermino
            });

            return Task.FromResult(projetosViewModel);
        }
    }
}