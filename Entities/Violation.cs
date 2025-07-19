using TrafficControlSystem.Contracts;

namespace TrafficControlSystem.Entities;
public class Violation : AuditableEntity
{
    public int Id { get; set; }
    public int LaneId { get; set; }
    public string VehicleNumber { get; set; }
    public int Speed { get; set; }
    public DateTime ViolationTime { get; set; }
}