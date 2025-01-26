using System;

namespace Entities;

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
        Nome = nome;
        Descricao = descricao;
        Status = status;
        DataDeVencimento = dataDeVencimento;
        DataDeInicio = dataDeInicio;
        Prioridade = prioridade;
    }

}
