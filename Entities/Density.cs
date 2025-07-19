using TrafficControlSystem.Contracts;

namespace TrafficControlSystem.Entities;

public class TrafficDensity : AuditableEntity
{
    public int Id { get; set; }
    public int LaneId { get; set; }
    public int Density { get; set; }
    public DateTime Date { get; set; }

}