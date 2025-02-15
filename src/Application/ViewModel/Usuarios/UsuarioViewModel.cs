using System;

namespace Application.ViewModel.Usuarios;

public class UsuarioViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    
}
