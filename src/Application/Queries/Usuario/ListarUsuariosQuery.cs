using MediatR;
using Application.ViewModel.Usuarios;

namespace Application.Queries.Usuario;

public class ListarUsuariosQuery : IRequest<IEnumerable<UsuarioViewModel>>
{

}
