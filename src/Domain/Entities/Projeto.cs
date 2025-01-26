using System;

namespace Entities;

public class Projeto
{

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DadosDaCriacao{ get; set; }
    public DateTime DataDeTermino{ get; set; }
    public string Status { get; set; }
    public string Prioridade { get; set; }
    public string Categoria { get; set; }

    
    public Projeto(string nome, string descricao, DateTime dadosDaCriacao, DateTime dataDeTermino, string status, string prioridade, string categoria)
    {
        Nome = nome;
        Descricao = descricao;
        DadosDaCriacao = dadosDaCriacao;
        DataDeTermino = dataDeTermino;
        Status = status;
        Prioridade = prioridade;
        Categoria = categoria;
    }
}
