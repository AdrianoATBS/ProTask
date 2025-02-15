using MediatR;
using Application.ViewModel.Usuarios;

namespace Application.Queries.Usuario;

public class ObterUsuarioPorEmailQuery : IRequest<UsuarioViewModel>
{
    public string Email { get; set; }
}
