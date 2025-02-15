// Application/Handlers/Projeto/ExcluirProjetoCommandHandler.cs
using MediatR;
using Domain.Interfaces;
using Application.Commands.Projetos;

namespace Application.Handlers.Projeto
{
    public class ExcluirProjetoCommandHandler : IRequestHandler<ExcluirProjetoCommand, Unit>
    {
        private readonly IProjetoRepository _repository;

        public ExcluirProjetoCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirProjetoCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterPorIdAsync(request.Id);
            if (projeto == null)
                throw new KeyNotFoundException("Projeto não encontrado");

            _repository.Remover(request.Id);
            return Unit.Value;
        }
    }
}