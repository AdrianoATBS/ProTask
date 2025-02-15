using MediatR;
using System;

namespace Application.Commands.Usuarios;

public class CriarUsuarioCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
}
