
using MediatR;
using Application.ViewModel.Projetos;
using Domain.Interfaces;
using Application.Queries.Projetos;

namespace Application.Handlers.Projeto
{
    public class ObterProjetoPorIdQueryHandler : IRequestHandler<ObterProjetoPorIdQuery, ProjetoViewModel>
    {
        private readonly IProjetoRepository _repository;

        public ObterProjetoPorIdQueryHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjetoViewModel> Handle(ObterProjetoPorIdQuery request, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterPorIdAsync(request.Id);
            if (projeto == null)
                throw new KeyNotFoundException("Projeto não encontrado");

            return new ProjetoViewModel
            {
                Id = projeto.HashDeConvite,
                Nome = projeto.Nome,
                Status = projeto.Status,
                DataTermino = projeto.DataDeTermino
            };
        }
    }
}