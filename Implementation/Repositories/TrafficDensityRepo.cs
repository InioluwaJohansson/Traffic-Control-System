using TrafficControlSystem.Context;
using TrafficControlSystem.Entities;
using TrafficControlSystem.Interface.Respositories;

namespace TrafficControlSystem.Implementation.Respositories;
public class TrafficDensityRepo : BaseRepository<TrafficDensitys>, ITrafficDensityRepo
{
    public TrafficDensityRepo(TrafficControlSystemContext _context)
    {
        context = _context;
    }

}