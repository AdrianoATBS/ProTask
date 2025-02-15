using MediatR;
using Application.ViewModel.Projetos;

namespace Application.Queries.Projetos;

public class ListarProjetosPorStatusQuery : IRequest<IEnumerable<ProjetoViewModel>>
{
    public string Status { get; set; }
}
