using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
       
        void Adicionar(Usuario usuario);
        Usuario ObterPorId(Guid id);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ListarTodos();
        void Atualizar(Usuario usuario);
        void Remover(Guid id);
        bool EmailExiste(string email);
        IEnumerable<Usuario> ListarPorCargo(string cargo);


        Task AdicionarAsync(Usuario usuario);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<Usuario> ObterPorIdAsync(Guid id); // 
    }
}