using System;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IProjetoRepository
{
    void Adicionar(Projeto projeto);
    Projeto ObterPorId(Guid id);
    IEnumerable<Projeto> ListarTodos();
    void Atualizar(Projeto projeto);
    void Remover(Guid id);
    IEnumerable<Projeto> ListarPorStatus(string status);
    IEnumerable<Projeto> ListarPorPrioridade(string prioridade);

    Task AdicionarAsync(Projeto projeto);
    Task<Projeto> ObterPorIdAsync(Guid id);
}
