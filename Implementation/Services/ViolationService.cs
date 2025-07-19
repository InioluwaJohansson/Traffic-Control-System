using TrafficControlSystem.Entities;
using TrafficControlSystem.Interface.Respositories;
using TrafficControlSystem.Interface.Services;
using TrafficControlSystem.Models.DTOs;

namespace TrafficControlSystem.Implementation.Services;

public class ViolationService : IViolationService
{
    IViolationRepo _violationRepo;
    public ViolationService(IViolationRepo violationRepo)
    {
        _violationRepo = violationRepo;
    }
    public async Task<BaseResponse> CreateViolation(CreateViolationDto createViolationDto)
    {
        if (createViolationDto != null)
        {
            var violation = new Violation()
            {
                VehicleNumber = createViolationDto.VehicleNumber,
                LaneId = createViolationDto.LaneId,
                ViolationTime = DateTime.UtcNow,
                Speed = createViolationDto.Speed,
                ImageUrl = createViolationDto.Image 
            };
            await _violationRepo.Create(violation);
            return new BaseResponse
            {
                Status = true,
                Message = "Violation created successfully."
            };
        }
        return new BaseResponse
        {
            Status = false,
            Message = "Invalid violation data."
        };
    }
    public async Task<ViolationsResponse> GetAllViolations()
    {
        var violations = await _violationRepo.GetAll();
        if (violations != null && violations.Any())
        {
            return new ViolationsResponse
            {
                Status = true,
                Message = "Violations retrieved successfully.",
                Violations = violations.OrderByDescending(x => x.ViolationTime).Select(x => new GetViolationDto
                {
                    Id = x.Id,
                    VehicleNumber = x.VehicleNumber,
                    LaneId = x.LaneId,
                    Speed = x.Speed,
                    ViolationTime = x.ViolationTime
                }).ToList()
            };
        }
        return new ViolationsResponse
        {
            Status = false,
            Message = "No violations found."
        };
    }
}

