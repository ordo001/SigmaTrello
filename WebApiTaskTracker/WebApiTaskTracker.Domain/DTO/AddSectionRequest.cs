using System.ComponentModel.DataAnnotations;

namespace WebApiTaskTracker.Domain.DTO;

public class AddSectionRequest
{
    [Required(ErrorMessage = "Имя обязально")]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Позиция обязальна")]
    public int Position { get; set; }
}