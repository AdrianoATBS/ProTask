using MediatR;
using Domain.Interfaces;
using Application.Commands.Tarefa;

namespace Application.Handlers.Tarefa
{
    public class ExcluirTarefaCommandHandler : IRequestHandler<ExcluirTarefaCommand, Unit>
    {
        private readonly ITarefaRepository _repository;

        public ExcluirTarefaCommandHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _repository.ObterPorIdAsync(request.Id);
            if (tarefa == null)
                throw new KeyNotFoundException("Tarefa não encontrada");

            _repository.Remover(request.Id);
            return Unit.Value;
        }
    }
}