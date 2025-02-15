using MediatR;
using Domain.Interfaces;
using Application.Queries.Projetos;
using Application.ViewModel.Projetos;

namespace Application.Handlers.Projeto
{
    public class ListarProjetosPorStatusQueryHandler : IRequestHandler<ListarProjetosPorStatusQuery, IEnumerable<ProjetoViewModel>>
    {
        private readonly IProjetoRepository _repository;

        public ListarProjetosPorStatusQueryHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ProjetoViewModel>> Handle(ListarProjetosPorStatusQuery request, CancellationToken cancellationToken)
        {
            var projetos = _repository.ListarPorStatus(request.Status);
            var projetosViewModel = projetos.Select(p => new ProjetoViewModel
            {
                Id = p.HashDeConvite,
                Nome = p.Nome,
                Status = p.Status
            });

            return Task.FromResult(projetosViewModel);
        }
    }
}