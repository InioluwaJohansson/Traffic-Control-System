using TrafficControlSystem.Context;
using TrafficControlSystem.Entities;
using TrafficControlSystem.Interface.Respositories;

namespace TrafficControlSystem.Implementation.Respositories;
public class ViolationRepo : BaseRepository<Violation>, IViolationRepo
{
    public ViolationRepo(TrafficControlSystemContext _context)
    {
        context = _context;
    }

}