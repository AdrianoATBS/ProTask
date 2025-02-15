// Application/Handlers/Usuario/ObterUsuarioPorEmailQueryHandler.cs
using MediatR;
using Domain.Interfaces;
using Application.Queries.Usuario;
using Application.ViewModel.Usuarios;

namespace Application.Handlers.Usuario
{
    public class ObterUsuarioPorEmailQueryHandler : IRequestHandler<ObterUsuarioPorEmailQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _repository;

        public ObterUsuarioPorEmailQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioViewModel> Handle(ObterUsuarioPorEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.ObterPorEmailAsync(request.Email);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            return new UsuarioViewModel
            {
                Id = usuario.Hash,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Cargo = usuario.Cargo
            };
        }
    }
}