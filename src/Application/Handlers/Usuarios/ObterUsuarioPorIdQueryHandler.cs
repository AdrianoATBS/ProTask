using MediatR;
using Domain.Interfaces;
using Application.ViewModel.Usuarios;
using Application.Queries.Usuario;

namespace Application.Handlers.Usuario
{
    public class ObterUsuarioPorIdQueryHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _repository;

        public ObterUsuarioPorIdQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioViewModel> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.ObterPorIdAsync(request.Id);
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