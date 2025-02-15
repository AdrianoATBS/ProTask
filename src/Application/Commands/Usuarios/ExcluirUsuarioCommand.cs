using MediatR;
namespace Application.Commands.Usuarios;

public class ExcluirUsuarioCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
