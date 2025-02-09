using System;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IUsuarioRepository
{
    void Adicionar(Usuario usuario);
    Usuario ObterPorId(Guid id);
    Usuario ObterPorEmail(string email);
    IEnumerable<Usuario> ListarTodos();

    void Atualizar(Usuario usuario);
    void Remover(Guid id);
    Task AdicionarAsync(Usuario usuario);
    Task<Usuario> ObterPorEmailAsync(string email);
    bool EmailExiste(string email); // Verifica se o email já está cadastrado
    IEnumerable<Usuario> ListarPorCargo(string cargo);
}
