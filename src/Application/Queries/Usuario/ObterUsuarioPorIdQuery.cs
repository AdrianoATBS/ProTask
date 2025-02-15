using MediatR;
using Application.ViewModel.Usuarios;

namespace Application.Queries.Usuario;

public class ObterUsuarioPorIdQuery : IRequest<UsuarioViewModel>
{
    public Guid Id { get; set; }
}
