using System.ComponentModel.DataAnnotations;
using WebApiTaskTracker.Domain.Interfaces.Services;

public class ValidatorService : IValidatorService
{
    public List<ValidationResult?> ValidationEntity<T>(T validationEntity)
    {
        var context = new ValidationContext(validationEntity);
        var result = new List<ValidationResult>();
        if (!Validator.TryValidateObject(validationEntity, context, result, true))
        {
            return result!;
        }

        return result!;
    }
}