using PointsOfInterest.Application.DTOs;
using PointsOfInterest.Domain.Entities;

namespace PointsOfInterest.Application.Interfaces
{
    public interface IGpsService
    {
        Task<PointOfInterest> CreatePointOfInterest(CreatePointOfInterestDTO poiDto);
        Task<PointOfInterest?> GetPointOfInterestById(Guid id);
        Task<IEnumerable<PointOfInterest>> GetAllPointsOfInterest();
        Task<IEnumerable<PointOfInterest>> GetNearbyPointsOfInterest(int x, int y, int maxDistance);
        Task DeleteById(Guid id);
    }
}
