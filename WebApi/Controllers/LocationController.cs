using Domain.DTOs.LocationDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/Locations")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetLocationsDTO>>> GetLocations()
    {
        return await locationService.GetLocations();
    }

    [HttpGet("{locationId:int}")]
    public async Task<Response<GetLocationsDTO>> GetLocationById(int locationId)
    {
        return await locationService.GetLocationById(locationId);
    }

    [HttpPost]
    public async Task<Response<string>> AddLocation(AddLocationDTO location)
    {
        return await locationService.AddLocation(location);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateLocation(UpdateLocationDTO location)
    {
        return await locationService.UpdateLocation(location);
    }

    [HttpDelete("{locationId:int}")]
    public async Task<Response<bool>> DeleteLocation(int locationId)
    {
        return await locationService.DeleteLocation(locationId);
    }
}
