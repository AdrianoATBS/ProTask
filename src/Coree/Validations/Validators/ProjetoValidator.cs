using System;

namespace Core.Validations.Validators;

public class ProjetoValidator
{
    //Validação especifica apra a categoria do projeto
    public static ValidationResult ValidarCategoria(string categoria)
    {
        var categoriasValidas = new[] {"Desenvolvimento", "Design", "Marketing", "RH" };
        return Array.Exists(categoriasValidas, c => c.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            ? new ValidationResult(true)
            : new ValidationResult(false, "Categoria inválida");
    }
    // Validaçãoi específica para a data de término do projeto
    public static ValidationResult ValidarDataTermino(DateTime dataTermino, DateTime dataCriacao)
    {
        return dataTermino > dataCriacao
            ? new ValidationResult(true)
            : new ValidationResult(false,"Data de término deve ser maior que a data de criação");
    }
}
