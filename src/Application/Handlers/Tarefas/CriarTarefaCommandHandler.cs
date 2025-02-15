using MediatR;
using Domain.Interfaces;
using Application.Commands.Tarefa;

namespace Application.Handlers.Tarefa
{
    public class CriarTarefaCommandHandler : IRequestHandler<CriarTarefaCommand, Guid>
    {
        private readonly ITarefaRepository _repository;

        public CriarTarefaCommandHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CriarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new Domain.Entities.Tarefa(
                request.Nome,
                request.Descricao,
                "Pendente", 
                request.DataVencimento,
                DateTime.UtcNow, 
                "Média" 
            )
            {
                ProjetoId = request.ProjetoId
            };

            await _repository.AdicionarAsync(tarefa);
            return tarefa.Id;
        }
    }
}