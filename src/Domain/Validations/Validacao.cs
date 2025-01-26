using System;

namespace Validations;

public class ValidationResult
{
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResult(bool isValid, string errorMessage = "")
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
}
public static class Validacao
{
        public static ValidationResult ValidarEmail(string email)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email)
                ? new ValidationResult(true)
                : new ValidationResult(false, "Email inválido");
        }

        public static ValidationResult ValidarNome(string nome)
        {
            return string.IsNullOrWhiteSpace(nome)
                ? new ValidationResult(false, "Nome não pode ser vazio ou nulo")
                : new ValidationResult(true);
        }

        public static ValidationResult ValidarSenha(string senha)
        {
            return senha.Length >= 6
                ? new ValidationResult(true)
                : new ValidationResult(false, "A senha deve ter pelo menos 6 caracteres");
        }

        public static ValidationResult ValidarCargo(string cargo)
        {
            var cargosValidos = new[] { "Lider", "Administrador", "Membro" };
            return Array.Exists(cargosValidos, c => c.Equals(cargo, StringComparison.OrdinalIgnoreCase))
                ? new ValidationResult(true)
                : new ValidationResult(false, "Cargo inválido");
        }

        public static ValidationResult ValidarDataCriacao(DateTime dataDeCriacao)
        {
            return dataDeCriacao <= DateTime.Now
                ? new ValidationResult(true)
                : new ValidationResult(false, "Data de criação não pode ser no futuro");
        }

        public static ValidationResult ValidarStatusAceitacao(bool statusDeAceitacao)
        {
            return statusDeAceitacao == true || statusDeAceitacao == false
                ? new ValidationResult(true)
                : new ValidationResult(false, "Status de aceitação inválido");
        }
}