using MediatR;

namespace Application.Commands.Tarefa
{
    public class AtualizarTarefaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}