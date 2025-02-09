using System;

namespace Core.Validations.Validators;

public class UsuarioValidator
{
    //Validação específica para o cargo do usuário
    public static ValidationResult ValidarCargo(string cargo)
    {
        var cargosValidos =new[] {"Lider", "Administrador", "Membro"};
        return Array.Exists(cargosValidos, c => c.Equals(cargo, StringComparison.OrdinalIgnoreCase))
            ? new ValidationResult(true)
            : new ValidationResult(false, "Cargo inválido");
    }

    // //Validação específica para o status de aceitação do usuário
    public static ValidationResult ValidarStatusAceitacao(bool statusDeAceitacao)
    {
        return statusDeAceitacao == true || statusDeAceitacao == false
            ? new ValidationResult(true)
           : new ValidationResult(false, "Status de aceitação inválido");
    }
}
