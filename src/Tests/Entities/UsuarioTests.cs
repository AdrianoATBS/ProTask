using System;
using Entities;
using Exceptions;
using Validations;
using Xunit;

namespace Tests.Teste
{
    public class UsuarioTests
    {
            [Fact]
            public void DeveLancarExcecaoQuandoNomeForInvalido()
            {
                // Arrange
                var nomeInvalido = "";
                var emailValido = "email@dominio.com";
                var cargoValido = "Membro";
                var statusDeAceitacaoValido = true;
                var dataDeCriacaoValida = DateTime.Now;
                var ultimoLoginValido = DateTime.Now;

                // Act & Assert
                var exception = Assert.Throws<ValidacaoException>(() =>
                    new Usuario(Guid.NewGuid(), nomeInvalido, emailValido, cargoValido, statusDeAceitacaoValido, dataDeCriacaoValida, ultimoLoginValido)
                );

                Assert.Contains("Nome não pode ser vazio ou nulo", exception.Erros); // Verificando na lista de erros
            }

        [Fact]
        public void DeveCriarUsuarioComDadosValidos()
        {
            // Arrange
            var nomeValido = "João Silva";
            var emailValido = "joao.silva@dominio.com";
            var cargoValido = "Membro";
            var statusDeAceitacaoValido = true;
            var dataDeCriacaoValida = DateTime.Now;
            var ultimoLoginValido = DateTime.Now;

            // Act
            var usuario = new Usuario(Guid.NewGuid(), nomeValido, emailValido, cargoValido, statusDeAceitacaoValido, dataDeCriacaoValida, ultimoLoginValido);

            // Assert
            Assert.Equal(nomeValido, usuario.Nome);
            Assert.Equal(emailValido, usuario.Email);
            Assert.Equal(cargoValido, usuario.Cargo);
            Assert.Equal(statusDeAceitacaoValido, usuario.StatusDeAceitacao);
        }

       [Fact]
        public void DeveLancarExcecaoQuandoEmailForInvalido()
        {
            // Arrange
            var nomeValido = "Maria Souza";
            var emailInvalido = "maria@dominio";
            var cargoValido = "Lider";
            var statusDeAceitacaoValido = true;
            var dataDeCriacaoValida = DateTime.Now;
            var ultimoLoginValido = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<ValidacaoException>(() =>
                new Usuario(Guid.NewGuid(), nomeValido, emailInvalido, cargoValido, statusDeAceitacaoValido, dataDeCriacaoValida, ultimoLoginValido)
            );

            // Verificando se a lista de erros contém a mensagem esperada
            Assert.Contains("Email inválido", exception.Erros);
        }

    }
}
