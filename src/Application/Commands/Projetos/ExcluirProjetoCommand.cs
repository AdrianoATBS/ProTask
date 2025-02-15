using MediatR;

namespace Application.Commands.Projetos;

public class ExcluirProjetoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
