using MediatR;
using Domain.Interfaces;
using Application.Commands.Projetos;


namespace Application.Handlers.Projeto;

public class CriarProjetoCommandHandler : IRequestHandler<CriarProjetoCommand, Guid>
{
    private readonly IProjetoRepository _repository;

    public CriarProjetoCommandHandler(IProjetoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CriarProjetoCommand request, CancellationToken cancellationToken)
    {
        var projeto = new Domain.Entities.Projeto(
            request.Nome,
            request.Descricao,
            DateTime.UtcNow,
            request.DataTermino,
            "Em andamento",
            "Média",
            request.Categoria
            );

            await _repository.AdicionarAsync(projeto);
            return projeto.HashDeConvite;
    }
}

