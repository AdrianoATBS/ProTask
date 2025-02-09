using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly List<Tarefa> _tarefas = new();

    public void Adicionar(Tarefa tarefa)
    {
        _tarefas.Add(tarefa);
    }

    public Tarefa ObterPorId(Guid id)
    {
        return _tarefas.FirstOrDefault(t => t.Id == id); // Adicione uma propriedade Id na entidade Tarefa
    }

    public IEnumerable<Tarefa> ListarTodos()
    {
        return _tarefas;
    }

    public void Atualizar(Tarefa tarefa)
    {
        var tarefaExistente = ObterPorId(tarefa.Id);
        if (tarefaExistente != null)
        {
            tarefaExistente.Nome = tarefa.Nome;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Status = tarefa.Status;
            tarefaExistente.Prioridade = tarefa.Prioridade;
            tarefaExistente.DataDeVencimento = tarefa.DataDeVencimento;
        }
    }

    public void Remover(Guid id)
    {
        var tarefa = ObterPorId(id);
        if (tarefa != null)
        {
            _tarefas.Remove(tarefa);
        }
    }

    public Task AdicionarAsync(Tarefa tarefa)
    {
        Adicionar(tarefa);
        return Task.CompletedTask;
    }

    public Task<Tarefa> ObterPorIdAsync(Guid id)
    {
        return Task.FromResult(ObterPorId(id));
    }

    public IEnumerable<Tarefa> ListarPorProjeto(Guid projetoId)
    {
        return _tarefas.Where(t => t.ProjetoId == projetoId); // Adicione uma propriedade ProjetoId na entidade Tarefa
    }

    public IEnumerable<Tarefa> ListarTarefasAtrasadas()
    {
        return _tarefas.Where(t => t.DataDeVencimento < DateTime.Now && t.Status != "Concluído");
    }
}