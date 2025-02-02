using System;

namespace Core.Validations.Validators;

public class TarefaValidator
{
    //Validação específica para o status da tarefa
    public static ValidationResult ValidarStatusTarefa(string status)
    {
        var statusValidos = new[] { "Pendentes", "Em progresso", "Concluido",};
        return Array.Exists(statusValidos, s => s.Equals(status, StringComparison.OrdinalIgnoreCase))
            ? new ValidationResult(true)
            : new ValidationResult(false, "Status da tarefa inválido");
    }
    //Validação específica para a data de vencimento da tarefa
    public static ValidationResult ValidarDataVencimento(DateTime dataVencimento, DateTime dataInicio)
    {
        return dataVencimento > dataInicio
            ? new ValidationResult(true)
            : new ValidationResult(false, "Data de vencimento deve ser maior que a data de inicio");
    }
}
