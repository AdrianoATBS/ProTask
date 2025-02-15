using MediatR;
using Application.ViewModel.Usuarios;
using Domain.Interfaces;
using Application.Queries.Usuario;

namespace Application.Handlers.Usuario
{
    public class ListarUsuarioQueryHandler : IRequestHandler<ListarUsuariosQuery, IEnumerable<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _repository;

        public ListarUsuarioQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<UsuarioViewModel>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = _repository.ListarTodos();
            var usuariosViewModel = usuarios.Select(u => new UsuarioViewModel
            {
                Id = u.Hash,
                Nome = u.Nome,
                Email = u.Email
            });

            return Task.FromResult(usuariosViewModel);
        }
    }
}