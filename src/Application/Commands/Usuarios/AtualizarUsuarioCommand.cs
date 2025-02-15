using MediatR;

namespace Application.Commands.Usuarios
{
    public class AtualizarUsuarioCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
    }
}