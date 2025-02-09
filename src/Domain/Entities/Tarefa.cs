using Core.Exceptions;
using Core.Validations;
using Core.Validations.Validators;

namespace Domain.Entities;

public class Tarefa
{

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
    public DateTime DataDeVencimento { get; set; }
    public DateTime DataDeInicio { get; set; }
    public string Prioridade { get; set; }

    public Tarefa(string nome, string descricao, string status, DateTime dataDeVencimento, DateTime dataDeInicio, string prioridade)
    {
        // Validação do nome
        var resultadoNome = Validacao.ValidarNome(nome);
        if (!resultadoNome.IsValid)
            throw new ValidacaoException(resultadoNome.ErrorMessage, 301);

        // Validação da descrição
        var resultadoDescricao = Validacao.ValidarNome(descricao);
        if (!resultadoDescricao.IsValid)
            throw new ValidacaoException(resultadoDescricao.ErrorMessage, 302);

        // Validação do status usando TarefaValidator
        var resultadoStatus = TarefaValidator.ValidarStatusTarefa(status);
        if (!resultadoStatus.IsValid)
            throw new ValidacaoException(resultadoStatus.ErrorMessage, 303);

        // Validação da data de vencimento usando TarefaValidator
        var resultadoDataVencimento = TarefaValidator.ValidarDataVencimento(dataDeVencimento, dataDeInicio);
        if (!resultadoDataVencimento.IsValid)
            throw new ValidacaoException(resultadoDataVencimento.ErrorMessage, 304);
        
        Nome = nome;
        Descricao = descricao;
        Status = status;
        DataDeVencimento = dataDeVencimento;
        DataDeInicio = dataDeInicio;
        Prioridade = prioridade;
    }

}
