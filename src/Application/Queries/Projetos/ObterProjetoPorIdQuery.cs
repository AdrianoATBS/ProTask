using MediatR;
using Application.ViewModel.Projetos;

namespace Application.Queries.Projetos;

public class ObterProjetoPorIdQuery :IRequest<ProjetoViewModel>
{
    public Guid Id { get; set; }    
}
