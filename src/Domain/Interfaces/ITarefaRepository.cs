using System;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ITarefaRepository
{
    void Adicionar(Tarefa tarefa);
    Tarefa ObterPorId(Guid id);

    IEnumerable<Tarefa> ListarTodos();
    void Atualizar(Tarefa tarefa);
    void Remover(Guid id);


    IEnumerable<Tarefa> ListarPorProjeto(Guid projetoId);
    IEnumerable<Tarefa> ListarTarefaAtrasada();


    Task AdicionarAsync(Tarefa tarefa);
    Task<Tarefa> ObterPorIdAsync(Guid id);
}
