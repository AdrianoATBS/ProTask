using MediatR;
using Domain.Interfaces;
using Application.Commands.Usuarios;

namespace Application.Handlers.Usuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.ObterPorIdAsync(request.Id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Cargo = request.Cargo;

            _repository.Atualizar(usuario);
            return Unit.Value;
        }
    }
}