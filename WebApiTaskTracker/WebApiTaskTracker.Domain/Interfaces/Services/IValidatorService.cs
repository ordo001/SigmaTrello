namespace WebApiTaskTracker.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Интерфейс для проверки валидации сущностей.
/// </summary>
public interface IValidatorService
{
    /// <summary>
    /// Выполняет валидацию переданного объекта и возвращает список результатов проверки.
    /// </summary>
    /// <typeparam name="T">Тип объекта, подлежащего валидации.</typeparam>
    /// <param name="validationEntity">Объект, который нужно проверить.</param>
    /// <returns>Список результатов валидации. Если проверка успешна, возвращается пустой список.</returns>
    public List<ValidationResult?> ValidationEntity<T>(T validationEntity);
}