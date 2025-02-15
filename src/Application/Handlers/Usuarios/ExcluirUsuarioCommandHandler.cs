using MediatR;
using Domain.Interfaces;
using Application.Commands.Usuarios;

namespace Application.Handlers.Usuario
{
    public class ExcluirUsuarioCommandHandler : IRequestHandler<ExcluirUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;

        public ExcluirUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.ObterPorIdAsync(request.Id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            _repository.Remover(request.Id);
            return Unit.Value;
        }
    }
}