namespace WebApiTaskTracker.Domain.DTO;

public class UpdatePositionSectionRequest
{
    public Guid IdSection { get; set; }
    public int Position { get; set; }
}