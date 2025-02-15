using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ProjetoRepository : IProjetoRepository
{
    private readonly List<Projeto> _projetos = new();

    public void Adicionar(Projeto projeto)
    {
        _projetos.Add(projeto);
    }

    public Projeto ObterPorId(Guid id)
    {
        return _projetos.FirstOrDefault(p => p.HashDeConvite == id);
    }

    public IEnumerable<Projeto> ListarTodos()
    {
        return _projetos;
    }

    public void Atualizar(Projeto projeto)
    {
        var projetoExistente = ObterPorId(projeto.HashDeConvite);
        if (projetoExistente != null)
        {
            projetoExistente.Nome = projeto.Nome;
            projetoExistente.Descricao = projeto.Descricao;
            projetoExistente.Status = projeto.Status;
            projetoExistente.Prioridade = projeto.Prioridade;
            projetoExistente.Categoria = projeto.Categoria;
            projetoExistente.DataDeTermino = projeto.DataDeTermino;
        }
    }

    public void Remover(Guid id)
    {
        var projeto = ObterPorId(id);
        if (projeto != null)
        {
            _projetos.Remove(projeto);
        }
    }

    public Task AdicionarAsync(Projeto projeto)
    {
        Adicionar(projeto);
        return Task.CompletedTask;
    }

    public Task<Projeto> ObterPorIdAsync(Guid id)
    {
        return Task.FromResult(ObterPorId(id));
    }

    public IEnumerable<Projeto> ListarPorStatus(string status)
    {
        return _projetos.Where(p => p.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Projeto> ListarPorPrioridade(string prioridade)
    {
        return _projetos.Where(p => p.Prioridade.Equals(prioridade, StringComparison.OrdinalIgnoreCase));
    }

    public Task<IEnumerable<Projeto>> ListarTodosAsync()
    {
        throw new NotImplementedException();
    }
}