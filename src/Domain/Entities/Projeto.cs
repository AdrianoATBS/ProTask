using Core.Exceptions;
using Core.Validations;
using Core.Validations.Validators;

namespace Domain.Entities;

public class Projeto
{

    public Guid HashDeConvite { get; private set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DadosDaCriacao{ get; set; }
    public DateTime DataDeTermino{ get; set; }
    public string Status { get; set; }
    public string Prioridade { get; set; }
    public string Categoria { get; set; }

    
    public Projeto(string nome, string descricao, DateTime dadosDaCriacao, DateTime dataDeTermino, string status, string prioridade, string categoria)
    {
        // Validação do nome
        var resultadoNome = Validacao.ValidarNome(nome);
        if (!resultadoNome.IsValid)
            throw new ValidacaoException(resultadoNome.ErrorMessage, 201);

        // Validação da categoria usando ProjetoValidator
        var resultadoCategoria = ProjetoValidator.ValidarCategoria(categoria);
        if (!resultadoCategoria.IsValid)
            throw new ValidacaoException(resultadoCategoria.ErrorMessage, 202);

        // Validação da data de término usando ProjetoValidator
        var resultadoDataTermino = ProjetoValidator.ValidarDataTermino(dataDeTermino, dadosDaCriacao);
        if (!resultadoDataTermino.IsValid)
            throw new ValidacaoException(resultadoDataTermino.ErrorMessage, 203);

        // Geração do hash de convite
        HashDeConvite = Guid.NewGuid();
            

        Nome = nome;
        Descricao = descricao;
        DadosDaCriacao = dadosDaCriacao;
        DataDeTermino = dataDeTermino;
        Status = status;
        Prioridade = prioridade;
        Categoria = categoria;
    }
}
