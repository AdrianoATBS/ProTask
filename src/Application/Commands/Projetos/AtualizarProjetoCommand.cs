using MediatR;
using System;

namespace Application.Commands.Projetos;

public class AtualizarProjetoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
}
