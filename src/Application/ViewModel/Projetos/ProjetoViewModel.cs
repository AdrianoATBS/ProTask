using System;

namespace Application.ViewModel.Projetos;

public class ProjetoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataTermino { get; set; }
    public string Status { get; set; }
}
