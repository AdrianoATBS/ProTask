// Domain/Interfaces/Validation/IValidator.cs
using Core.Validations;

namespace Domain.Interfaces.Validation;

public interface IValidator<T>
{
    ValidationResult Validar(T entidade);
}