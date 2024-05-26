using PointsOfInterest.Application.DTOs;
using PointsOfInterest.Application.Interfaces;
using PointsOfInterest.Domain.Core.Intefaces;
using PointsOfInterest.Domain.Entities;

namespace PointsOfInterest.Application.Services
{
    public sealed class GpsService : IGpsService
    {
        private readonly IPointOfInterestRepository _pointsOfInterestRepository;

        public GpsService(IPointOfInterestRepository pointsOfInterestRepository)
        {
            _pointsOfInterestRepository = pointsOfInterestRepository;
        }

        public async Task<PointOfInterest> CreatePointOfInterest(CreatePointOfInterestDTO poiDto)
        {
            PointOfInterest newPoi = new(poiDto.Name, poiDto.X, poiDto.Y);

            var createdPoi = await _pointsOfInterestRepository.Add(newPoi);
            
            return createdPoi;
        }

        public async Task<IEnumerable<PointOfInterest>> GetAllPointsOfInterest()
        {
            return await _pointsOfInterestRepository.GetAllWhere(p => true);
        }

        public async Task<IEnumerable<PointOfInterest>> GetNearbyPointsOfInterest(int x, int y, int maxDistance)
        {
            var points = await GetAllPointsOfInterest();
            
            List<PointOfInterest> nearbyPoints = new();

            foreach (var poi in points)
            {
                double distance = Math.Sqrt(Math.Pow(x - poi.X, 2) + Math.Pow(y - poi.Y, 2));
                if (distance <= maxDistance) nearbyPoints.Add(poi);
            }

            return nearbyPoints;
        }

        public async Task<PointOfInterest?> GetPointOfInterestById(Guid id)
        {
            return await _pointsOfInterestRepository.GetById(id);
        }

        public async Task DeleteById(Guid id)
        {
            var poiEntity = await _pointsOfInterestRepository.GetById(id);

            if (poiEntity is null) return;

            await _pointsOfInterestRepository.Delete(poiEntity);
        }
    }
}
