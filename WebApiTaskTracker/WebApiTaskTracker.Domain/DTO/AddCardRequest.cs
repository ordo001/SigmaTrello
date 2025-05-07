using System.ComponentModel.DataAnnotations;

namespace WebApiTaskTracker.Domain.DTO;

public class AddCardRequest
{
    [Required(ErrorMessage = "Имя обязательно")]
    [MinLength(1, ErrorMessage = "Минимальная длинна 1 символ")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Id создателя обязательно")]
    public Guid CreatorId { get; set; }

    [Required(ErrorMessage = "Id секции обязательно")]
    public int position { get; set; }
    public Guid SectionId { get; set; }
}