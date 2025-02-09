using Core.Exceptions;
using Domain.Entities;
using Xunit;

namespace Tests.UnitTests.Entities;

public class UsuarioTests
{
    [Fact]
    public void CriarUsuario_ComDadosValidos_DeveCriarUsuario()
    {
        // Arrange
        var hash = Guid.NewGuid();
        var nome = "João Silva";
        var email = "joao.silva@gmail.com";
        var cargo = "Membro";
        var statusDeAceitacao = true;
        var dataDeCriacao = DateTime.UtcNow;
        var ultimoLogin = DateTime.UtcNow;

        // Act
        var usuario = new Usuario(hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin);

        // Assert
        Assert.NotNull(usuario);
        Assert.Equal(nome, usuario.Nome);
        Assert.Equal(email, usuario.Email);
        Assert.Equal(cargo, usuario.Cargo);
        Assert.Equal(statusDeAceitacao, usuario.StatusDeAceitacao);
        Assert.Equal(dataDeCriacao, usuario.DataDeCriacao);
        Assert.Equal(ultimoLogin, usuario.UltimoLogin);
    }

    [Fact]
    public void CriarUsuario_ComNomeInvalido_DeveLancarExcecao()
    {
        // Arrange
        var hash = Guid.NewGuid();
        var nome = ""; // Nome inválido
        var email = "joao.silva@gmail.com";
        var cargo = "Membro";
        var statusDeAceitacao = true;
        var dataDeCriacao = DateTime.UtcNow;
        var ultimoLogin = DateTime.UtcNow;

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() =>
            new Usuario(hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));
        Assert.Equal(101, exception.CodigoErro);
        Assert.Contains("Nome não pode ser vazio ou nulo", exception.Message);
    }

    [Fact]
    public void CriarUsuario_ComEmailInvalido_DeveLancarExcecao()
    {
        // Arrange
        var hash = Guid.NewGuid();
        var nome = "João Silva";
        var email = "emailinvalido"; // E-mail inválido
        var cargo = "Membro";
        var statusDeAceitacao = true;
        var dataDeCriacao = DateTime.UtcNow;
        var ultimoLogin = DateTime.UtcNow;

        // Act & Assert
        var exception = Assert.Throws<ValidacaoException>(() =>
            new Usuario(hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));
        Assert.Equal(102, exception.CodigoErro);
        Assert.Contains("Email inválido", exception.Message);
    }
}

// using Core.Exceptions;
// using Domain.Entities;
// using Xunit;

// namespace Tests.UnitTests.Entities
// {
//     public class UsuarioTests
//     {
//         [Fact]
//         public void CriarUsuario_ComDadosValidos_DeveCriarUsuario()
//         {
//             // Arrange
//             var hash = Guid.NewGuid();
//             var nome = "João Silva";
//             var email = "joao.silva@gmail.com";
//             var cargo = "Membro";
//             var statusDeAceitacao = true;
//             var dataDeCriacao = DateTime.UtcNow;
//             var ultimoLogin = DateTime.UtcNow;

//             // Act
//             var usuario = new Usuario(hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin);

//             // Assert
//             Assert.NotNull(usuario);
//             Assert.Equal(nome, usuario.Nome);
//             Assert.Equal(email, usuario.Email);
//             Assert.Equal(cargo, usuario.Cargo);
//             Assert.Equal(statusDeAceitacao, usuario.StatusDeAceitacao);
//             Assert.Equal(dataDeCriacao, usuario.DataDeCriacao);
//             Assert.Equal(ultimoLogin, usuario.UltimoLogin);
//         }
//         [Fact]
//         public void CriarUsuario_ComNomeInvalido_DeveLancarExececao()
//         {
//             //Arrange
//             var hash = Guid.NewGuid();
//             var nome = ""; //Nome inválido
//             var email = "joao.silva@gmail.com";
//             var cargo = "Membro";
//             var statusDeAceitacao = true;
//             var dataDeCriacao = DateTime.UtcNow;
//             var ultimoLogin = DateTime.UtcNow;

//             // Act e Assert
//             var exception = Assert.Throws<ValidacaoException>(() => new Usuario(hash, nome, email,cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));

//             Assert.Equal(101, exception.CodigoErro);
//             Assert.Contains("Nome não pode ser vazio ou nulo", exception.Message);
//         }

//         [Fact]
//         public void CriarUsuario_ComEmailInvalido_DeveLancarExcecao()
//         {
//             // Arrange
//             var hash = Guid.NewGuid();
//             var nome = "João Silva";
//             var email = "emailinvalido"; 
//             var cargo = "Membro";
//             var statusDeAceitacao = true;
//             var dataDeCriacao = DateTime.UtcNow;
//             var ultimoLogin = DateTime.UtcNow;

//             // Act e Assert
//             var exception = Assert.Throws<ValidacaoException>(() =>
//                 new Usuario(hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));

//             Assert.Equal(102, exception.CodigoErro);
//             Assert.Contains("Email inválido", exception.Message);
//         }

//         [Fact]
//         public void CriarUsuario_ComCargoInvalido_DeveLancarExcecao()
//         {
//             // Arrange
//             var hash = Guid.NewGuid();
//             var nome = "João Silva";
//             var email = "joao.silva@gmail.com";
//             var cargo = "Gerente"; //Cargo inválido
//             var statusDeAceitacao = true;
//             var dataDeCriacao = DateTime.UtcNow;
//             var ultimoLogin = DateTime.UtcNow;

//             // Act e Assert
//             var exception = Assert.Throws<ValidacaoException>(() =>
//             new Usuario(hash,nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));

//             Assert.Equal(103, exception.CodigoErro);
//             Assert.Contains("Cargo inválido", exception.Message);
//         }

//         [Fact]
//         public void CriarUsuario_ComStatusDeAceitacaoInvalido_DeveLancarExcecao()
//         {
//             //Arrange
//             var hash = Guid.NewGuid();
//             var nome = "João Silva";
//             var email = "joao.Silva@gmail.com";
//             var cargo = "Membro";
//             bool statusDeAceitacao = true; //valor valido
//             var dataDeCriacao = DateTime.UtcNow;
//             var ultimoLogin = DateTime.UtcNow;

//             // Act e Assert
//             var exception = Record.Exception(() => new Usuario(hash, nome,email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));

//             Assert.Null(exception);
//         }

//         [Fact]
//         public void CriarUsuario_ComDataDeCriacaoNoFuturo_DeveLancarExcecao()
//         {
//             //Arrange
//             var hash = Guid.NewGuid();
//             var nome = "João Silva";
//             var email = "joao.silva@gmail.com";
//             var cargo = "Membro";
//             var statusDeAceitacao = true;
//             var dataDeCriacao = DateTime.UtcNow.AddDays(1); //Data um dia no futuro
//             var ultimoLogin = DateTime.UtcNow;

//             //Act e  Assert
//             var exception = Assert.Throws<ValidacaoException>(() => new Usuario (hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));

//             Assert.Equal(105, exception.CodigoErro);
//             Assert.Contains("Data de criação não pode ser no futuro", exception.Message);
//         }
//         [Fact]
//         public void CriarUsuario_ComUltimoLoginNoFuturo_DeveLancarExcecao()
//         {
//             //Arrange
//             var hash = Guid.NewGuid();
//             var nome = "João Silva";
//             var email = "joao.silva@gmail.com";
//             var cargo = "Membro";
//             var statusDeAceitacao = true;
//             var dataDeCriacao = DateTime.UtcNow;
//             var ultimoLogin = DateTime.UtcNow.AddDays(1);

//             var exception = Assert.Throws<ValidacaoException>(() =>
//             new Usuario(hash, nome, email, cargo, statusDeAceitacao, dataDeCriacao, ultimoLogin));

//             Assert.Equal(106, exception.CodigoErro); 
//             Assert.Contains("Último login não pode ser no futuro", exception.Message);
//         }

//     }
// }