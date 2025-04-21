namespace WebApiTaskTracker.Domain.DTO;

public class UpdatePositionSectionRequest
{
    Guid IdSection { get; set; }
    int Position { get; set; }
}