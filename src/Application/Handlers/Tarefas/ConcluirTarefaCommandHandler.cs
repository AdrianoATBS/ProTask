using MediatR;
using Domain.Interfaces;
using Application.Commands.Tarefa;

namespace Application.Handlers.Tarefa
{
    public class ConcluirTarefaCommandHandler : IRequestHandler<ConcluirTarefaCommand, Unit>
    {
        private readonly ITarefaRepository _repository;

        public ConcluirTarefaCommandHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ConcluirTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _repository.ObterPorIdAsync(request.TarefaId);
            if (tarefa == null)
                throw new KeyNotFoundException("Tarefa não encontrada");

            tarefa.Status = "Concluída";
            _repository.Atualizar(tarefa);
            return Unit.Value;
        }
    }
}