using MediatR;
using System;

namespace Application.Commands.Projetos;

public class CriarProjetoCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataTermino { get; set; }
    public string Categoria { get; set; }
}
