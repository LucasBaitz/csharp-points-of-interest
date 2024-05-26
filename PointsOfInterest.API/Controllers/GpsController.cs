using Microsoft.AspNetCore.Mvc;
using PointsOfInterest.Application.DTOs;
using PointsOfInterest.Application.Interfaces;

namespace PointsOfInterest.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public sealed class GpsController : ControllerBase
    {
        private readonly IGpsService _gpsService;
        public GpsController(IGpsService gpsService)
        {
            _gpsService = gpsService;
        }

        [HttpGet]
        [Route("Near/x={x}/y={y}/max-distance={dmax}")]
        public async Task<IActionResult> GetNearbyPoints(int x, int y, int dmax)
        {
            var nearbyPois = await _gpsService.GetNearbyPointsOfInterest(x, y, dmax);

            return Ok(nearbyPois);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllPoints()
        {
            var pois = await _gpsService.GetAllPointsOfInterest();
            return Ok(pois);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPointOfInterestById(Guid id)
        {
            var poi = await _gpsService.GetPointOfInterestById(id);

            if (poi is null) return NotFound();

            return Ok(poi);
        }

        [HttpPost]
        [Route("Create/Point")]
        public async Task<IActionResult> CreatePoint(CreatePointOfInterestDTO createPoiDto)
        {
            var createdPoi = await _gpsService.CreatePointOfInterest(createPoiDto);

            return CreatedAtAction(nameof(GetPointOfInterestById), new { id = createdPoi.Id }, createdPoi);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeletePointOfInterest(Guid id)
        {
            await _gpsService.DeleteById(id);

            return NoContent();
        }
    }
}
