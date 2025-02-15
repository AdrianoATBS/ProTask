using Domain.Entities;
using Domain.Interfaces;


namespace Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly List<Usuario> _usuarios = new(); // Simulação de banco de dados

    public void Adicionar(Usuario usuario)
    {
        _usuarios.Add(usuario);
    }

    public Usuario ObterPorId(Guid id)
    {
        return _usuarios.FirstOrDefault(u => u.Hash == id);
    }

    public Usuario ObterPorEmail(string email)
    {
        return _usuarios.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Usuario> ListarTodos()
    {
        return _usuarios;
    }

    public void Atualizar(Usuario usuario)
    {
        var usuarioExistente = ObterPorId(usuario.Hash);
        if (usuarioExistente != null)
        {
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Cargo = usuario.Cargo;
            usuarioExistente.StatusDeAceitacao = usuario.StatusDeAceitacao;
            usuarioExistente.DataDeCriacao = usuario.DataDeCriacao;
            usuarioExistente.UltimoLogin = usuario.UltimoLogin;
        }
    }

    public void Remover(Guid id)
    {
        var usuario = ObterPorId(id);
        if (usuario != null)
        {
            _usuarios.Remove(usuario);
        }
    }

    public Task AdicionarAsync(Usuario usuario)
    {
        Adicionar(usuario);
        return Task.CompletedTask;
    }

    public Task<Usuario> ObterPorEmailAsync(string email)
    {
        var usuario = ObterPorEmail(email);
        return Task.FromResult(usuario);
    }

    public bool EmailExiste(string email)
    {
        return _usuarios.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Usuario> ListarPorCargo(string cargo)
    {
        return _usuarios.Where(u => u.Cargo.Equals(cargo, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Usuario> ObterPorIdAsync(Guid id)
    {
        return await Task.FromResult(_usuarios.FirstOrDefault(u => u.Hash == id));
    }
}