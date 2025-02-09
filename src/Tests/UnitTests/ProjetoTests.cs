using Core.Exceptions;
using Domain.Entities;
using Xunit;

namespace Tests.UnitTests.Entities;

public class ProjetoTests
{
    [Fact]
    public void CriarProjeto_ComDadosValidos_DeveCriarProjeto()
    {
        // Arrange
        var nome = "Sistema de Gestão";
        var descricao = "Desenvolvimento de sistema integrado";
        var dadosDaCriacao = DateTime.UtcNow;
        var dataDeTermino = DateTime.UtcNow.AddDays(30);
        var status = "Em andamento";
        var prioridade = "Alta";
        var categoria = "Desenvolvimento";

        // Act
        var projeto = new Projeto(nome, descricao, dadosDaCriacao, dataDeTermino, status, prioridade, categoria);

        // Assert
        Assert.NotNull(projeto);
        Assert.Equal(nome, projeto.Nome);
        Assert.Equal(descricao, projeto.Descricao);
        Assert.Equal(dadosDaCriacao, projeto.DadosDaCriacao);
        Assert.Equal(dataDeTermino, projeto.DataDeTermino);
        Assert.Equal(status, projeto.Status);
        Assert.Equal(prioridade, projeto.Prioridade);
        Assert.Equal(categoria, projeto.Categoria);
    }

    [Fact]
    public void CriarProjeto_ComNomeInvalido_DeveLancarExcecao()
    {
        // Arrange
        var nome = ""; // Nome inválido
        var descricao = "Descrição válida";
        var dadosDaCriacao = DateTime.UtcNow;
        var dataDeTermino = DateTime.UtcNow.AddDays(10);
        var status = "Em andamento";
        var prioridade = "Alta";
        var categoria = "Desenvolvimento";

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Projeto(nome, descricao, dadosDaCriacao, dataDeTermino, status, prioridade, categoria));
        
        Assert.Equal(201, exception.CodigoErro);
        Assert.Contains("Nome não pode ser vazio ou nulo", exception.Message);
    }

    [Fact]
    public void CriarProjeto_ComCategoriaInvalida_DeveLancarExcecao()
    {
        // Arrange
        var nome = "Projeto válido";
        var descricao = "Descrição válida";
        var dadosDaCriacao = DateTime.UtcNow;
        var dataDeTermino = DateTime.UtcNow.AddDays(10);
        var status = "Em andamento";
        var prioridade = "Alta";
        var categoria = "Inválida"; // Categoria inválida

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Projeto(nome, descricao, dadosDaCriacao, dataDeTermino, status, prioridade, categoria));
        
        Assert.Equal(202, exception.CodigoErro);
        Assert.Contains("Categoria inválida", exception.Message);
    }

    [Fact]
    public void CriarProjeto_ComDataTerminoInvalida_DeveLancarExcecao()
    {
        // Arrange
        var nome = "Projeto válido";
        var descricao = "Descrição válida";
        var dadosDaCriacao = DateTime.UtcNow;
        var dataDeTermino = DateTime.UtcNow.AddHours(-1); // Data anterior
        var status = "Em andamento";
        var prioridade = "Alta";
        var categoria = "Desenvolvimento";

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Projeto(nome, descricao, dadosDaCriacao, dataDeTermino, status, prioridade, categoria));
        
        Assert.Equal(203, exception.CodigoErro);
        Assert.Contains("Data de término deve ser maior que a data de criação", exception.Message);
    }
}











// using Core.Exceptions;
// using Domain.Entities;
// using Xunit;

// namespace UnitTests
// {
//     public class ProjetoTests
//     {
//         [Fact]
//         public void CriarProjeto_ComDadosValidos_DeveCriarProjeto()
//         {
//             //Arrange
//             var nome = "Projeto de Desenvolvimento";
//             var descricao = "Este é um projeto de desenvolvimento.";
//             var dadosDaCriacao = DateTime.UtcNow;
//             var dataDeTermino = DateTime.UtcNow.AddDays(10);
//             var status = "Em andamento";
//             var prioridade = "Alta";
//             var categoria = "Desenvolvimento";

//             //Act
//             var projeto = new Projeto(nome, descricao, dadosDaCriacao, dataDeTermino, status, prioridade, categoria);

//             // Assert
//             Assert.NotNull(projeto);
//             Assert.Equal(nome, projeto.Nome);
//             Assert.Equal(descricao, projeto.Descricao);
//             Assert.Equal(dadosDaCriacao, projeto.DadosDaCriacao);
//             Assert.Equal(dataDeTermino, projeto.DataDeTermino);
//             Assert.Equal(status, projeto.Status);
//             Assert.Equal(prioridade, projeto.Prioridade);
//             Assert.Equal(categoria, projeto.Categoria);
//         }

//         [Fact]
//         public void CriarProjeto_ComCategoriaInvalida_DeveLancarExececao()
//         {
//             //Arrange
//             var nome = "Projeto de Desenvolvimento";
//             var descricao = "Este é um projeto de desenvolvimento.";
//             var dadosDaCriacao = DateTime.UtcNow;
//             var dataDeTermino = DateTime.UtcNow.AddDays(10);
//             var status = "Em andamento";
//             var prioridade = "Alta";
//             var categoria = "CategoriaInválida";

//             // Act e Assert
//             var exception = Assert.Throws<ValidacaoException> (() => new Projeto(nome,descricao, dadosDaCriacao, dataDeTermino, status, prioridade, categoria));

//             Assert.Equal(202, exception.CodigoErro);
//             Assert.Contains("Categoria inválida", exception.Message);
//         }
        
//     }
// }