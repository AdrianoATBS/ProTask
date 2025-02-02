using System;

namespace Core.Validations;

public class Validacao
{
    //Validação para e-mail (genérica)
    public static ValidationResult validarEmail(string email)
    {
        var regex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        return regex.IsMatch(email) 
            ? new ValidationResult(true)
            : new ValidationResult(false, "Email inválido");
    }
    //Validação genérica para nome
    public static ValidationResult ValidarNome(string nome)
    {
        return string.IsNullOrWhiteSpace(nome)
            ? new ValidationResult(false, "Nome não pode ser vazio ou nulo")
            : new ValidationResult(true);
    }

    //Validação genérica para datas
    public static ValidationResult ValidarData(DateTime data, DateTime dataReferencia, string mensagemErro)
    {
        return data > dataReferencia
            ? new ValidationResult(true)
            : new ValidationResult(false, mensagemErro);
    }
    // Validação do status de aceitação
    public static ValidationResult ValidarStatusAceitacao(bool statusDeAceitacao)
    {
        return statusDeAceitacao == true || statusDeAceitacao == false
            ? new ValidationResult(true)
            : new ValidationResult(false, "Status de aceitação inválido");
    }
    // Validação da data de criação
    public static ValidationResult ValidarDataCriacao(DateTime dataDeCriacao)
    {
        return dataDeCriacao <= DateTime.UtcNow
        ? new ValidationResult(true)
        : new ValidationResult(false, "Data de criação não pode ser no futuro");
    }
}
