using Core.Exceptions;
using Domain.Entities;
using Xunit;

namespace Tests.UnitTests.Entities;

public class TarefaTests
{
    [Fact]
    public void CriarTarefa_ComDadosValidos_DeveCriarTarefa()
    {
        // Arrange
        var nome = "Implementar API";
        var descricao = "Desenvolver endpoints da API";
        var status = "Pendente";
        var dataDeVencimento = DateTime.UtcNow.AddDays(5);
        var dataDeInicio = DateTime.UtcNow;
        var prioridade = "Alta";

        // Act
        var tarefa = new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade);

        // Assert
        Assert.NotNull(tarefa);
        Assert.Equal(nome, tarefa.Nome);
        Assert.Equal(descricao, tarefa.Descricao);
        Assert.Equal(status, tarefa.Status);
        Assert.Equal(dataDeVencimento, tarefa.DataDeVencimento);
        Assert.Equal(dataDeInicio, tarefa.DataDeInicio);
        Assert.Equal(prioridade, tarefa.Prioridade);
    }

    [Fact]
    public void CriarTarefa_ComNomeInvalido_DeveLancarExcecao()
    {
        // Arrange
        var nome = ""; // Nome inválido
        var descricao = "Descrição válida";
        var status = "Pendente";
        var dataDeVencimento = DateTime.UtcNow.AddDays(5);
        var dataDeInicio = DateTime.UtcNow;
        var prioridade = "Alta";

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade));
        
        Assert.Equal(301, exception.CodigoErro);
        Assert.Contains("Nome não pode ser vazio ou nulo", exception.Message);
    }

    [Fact]
    public void CriarTarefa_ComDescricaoInvalida_DeveLancarExcecao()
    {
        // Arrange
        var nome = "Tarefa válida";
        var descricao = ""; // Descrição inválida
        var status = "Pendente";
        var dataDeVencimento = DateTime.UtcNow.AddDays(5);
        var dataDeInicio = DateTime.UtcNow;
        var prioridade = "Alta";

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade));
        
        Assert.Equal(302, exception.CodigoErro);
        Assert.Contains("Nome não pode ser vazio ou nulo", exception.Message);
    }

    [Fact]
    public void CriarTarefa_ComStatusInvalido_DeveLancarExcecao()
    {
        // Arrange
        var nome = "Tarefa válida";
        var descricao = "Descrição válida";
        var status = "Inválido"; // Status inválido
        var dataDeVencimento = DateTime.UtcNow.AddDays(5);
        var dataDeInicio = DateTime.UtcNow;
        var prioridade = "Alta";

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade));
        
        Assert.Equal(303, exception.CodigoErro);
        Assert.Contains("Status da tarefa inválido", exception.Message);
    }

    [Fact]
    public void CriarTarefa_ComDataVencimentoInvalida_DeveLancarExcecao()
    {
        // Arrange
        var nome = "Tarefa válida";
        var descricao = "Descrição válida";
        var status = "Pendente";
        var dataDeVencimento = DateTime.UtcNow.AddHours(-1); // Data anterior
        var dataDeInicio = DateTime.UtcNow;
        var prioridade = "Alta";

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() => 
            new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade));
        
        Assert.Equal(304, exception.CodigoErro);
        Assert.Contains("Data de vencimento deve ser maior que a data de inicio", exception.Message);
    }
}



















// using Core.Exceptions;
// using Domain.Entities;
// using Xunit;

// namespace UnitTests
// {
//     public class TarefaTests
//     {
//         [Fact]
//         public void CriarTarefa_ComDadosValidos_DeveCriarTarefa()
//         {
//             //Arrange
//             var nome = "Tarefa de Desenvolvimento";
//             var descricao = "Esta é uma tarefa de desenvolvimento.";
//             var status = "Pendente";
//             var dataDeVencimento = DateTime.UtcNow.AddDays(5);
//             var dataDeInicio = DateTime.UtcNow;
//             var prioridade = "Alta";

//             //Act
//             var tarefa = new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade);

//             //Assert
//             Assert.NotNull(tarefa);
//             Assert.Equal(nome, tarefa.Nome);
//             Assert.Equal(descricao, tarefa.Descricao);
//             Assert.Equal(status, tarefa.Status);
//             Assert.Equal(dataDeVencimento, tarefa.DataDeVencimento);
//             Assert.Equal(prioridade, tarefa.Prioridade); 
//         }

//         [Fact]
//         public void CriarTarefa_ComStatusInvalido_DeveLancarExcecao()
//         {
//             // Arrange
//             var nome = "Tarefa de Desenvolvimento";
//             var descricao = "Esta é uma tarefa de desenvolvimento.";
//             var status = "StatusInválido"; //Status inválido
//             var dataDeVencimento = DateTime.UtcNow.AddDays(5);
//             var dataDeInicio = DateTime.UtcNow;
//             var prioridade = "Alta";

//             //Act e Assert
//             var exception = Assert.Throws<ValidacaoException>(() => new Tarefa(nome, descricao, status, dataDeVencimento, dataDeInicio, prioridade));

//             Assert.Equal(303, exception.CodigoErro);
//             Assert.Contains("Status da tarefa inválido", exception.Message);
//         }
//     }
// }