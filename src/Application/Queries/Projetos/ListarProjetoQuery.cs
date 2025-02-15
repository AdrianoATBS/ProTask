using MediatR;

using Application.ViewModel.Projetos;

namespace Application.Queries.Projetos;

public class ListarProjetoQuery : IRequest<IEnumerable<ProjetoViewModel>>
{
}
