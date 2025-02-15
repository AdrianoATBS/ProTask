
using MediatR;
using Domain.Interfaces;
using Application.Commands.Tarefa; 

namespace Application.Handlers.Tarefa
{
    public class AtualizarTarefaCommandHandler : IRequestHandler<AtualizarTarefaCommand, Unit>
    {
        private readonly ITarefaRepository _repository;

        public AtualizarTarefaCommandHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _repository.ObterPorIdAsync(request.Id);
            if (tarefa == null)
                throw new KeyNotFoundException("Tarefa não encontrada");

            tarefa.Nome = request.Nome;
            tarefa.Descricao = request.Descricao;
            tarefa.Status = request.Status;
            tarefa.DataDeVencimento = request.DataVencimento;

            _repository.Atualizar(tarefa);
            return Unit.Value;
        }
    }
}