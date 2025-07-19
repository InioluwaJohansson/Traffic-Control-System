namespace TrafficControlSystem.Models.DTOs;

public class CreateViolationDto
{
    public int LaneId { get; set; }
    public string VehicleNumber { get; set; }
    public DateTime ViolationTime { get; set; } = DateTime.UtcNow;
    public string Image { get; set; }
    public int Speed { get; set; }
}
public class GetViolationDto
{
    public int Id { get; set; }
    public int LaneId { get; set; }
    public string VehicleNumber { get; set; }
    public DateTime ViolationTime { get; set; }
    public int Speed { get; set; }
}
public class ViolationsResponse : BaseResponse
{
    public ICollection<GetViolationDto> Violations { get; set; } = new HashSet<GetViolationDto>();
}
