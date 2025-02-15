using MediatR;
using Domain.Interfaces;
using Application.Commands.Usuarios;

namespace Application.Handlers.Usuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _repository;

        public CriarUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Domain.Entities. Usuario(
                Guid.NewGuid(),
                request.Nome,
                request.Email,
                request.Cargo,
                true, 
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            await _repository.AdicionarAsync(usuario);
            return usuario.Hash;
        }
    }
}