using System.Net;
using Domain.DTOs.LocationDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService(DataContext context) : ILocationService
{
    public async Task<Response<List<GetLocationsDTO>>> GetLocations()
{
    try
    {
        var locations = await context.Locations.Where(x => x.Id > 0).ToListAsync();
        var list = new List<GetLocationsDTO>();
        foreach (var l in locations)
        {
            var location = new GetLocationsDTO()
            {
                Name = l.Name,
                Description = l.Description,
                Participants = l.Participants
            };
            list.Add(location);
        }

        return new Response<List<GetLocationsDTO>>(list);
    }
    catch (Exception e)
    {
        return new Response<List<GetLocationsDTO>>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<GetLocationsDTO>> GetLocationById(int id)
{
    try
    {
        var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
        if (location == null) return new Response<GetLocationsDTO>(HttpStatusCode.BadRequest, "Location not found");
        var response = new GetLocationsDTO()
        {
            Name = location.Name,
            Description = location.Description,
            Participants = location.Participants
        };
        return new Response<GetLocationsDTO>(response);
    }
    catch (Exception e)
    {
        return new Response<GetLocationsDTO>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<string>> AddLocation(AddLocationDTO location)
{
    try
    {
        var newLocation = new Location()
        {
            Name = location.Name,
            Description = location.Description,
            Participants = location.Participants
        };
        await context.Locations.AddAsync(newLocation);
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add");
    }
    catch (Exception e)
    {
        return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<string>> UpdateLocation(UpdateLocationDTO location)
{
    try
    {
        var updatedLocation = await context.Locations.FirstOrDefaultAsync(x => x.Id == location.Id);
        if (updatedLocation == null) return new Response<string>("Not found");
        updatedLocation.Name = location.Name;
        updatedLocation.Description = location.Description;
        updatedLocation.Participants = location.Participants;
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully updated");
        return new Response<string>("Failed to update");
    }
    catch (Exception e)
    {
        return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<bool>> DeleteLocation(int id)
{
    try
    {
        var existing = await context.Locations.FindAsync(id);
        if (existing == null) return new Response<bool>(HttpStatusCode.BadRequest, "Location not found");
        context.Locations.Remove(existing);
        var res = await context.SaveChangesAsync();
        return new Response<bool>(true);
    }
    catch (Exception e)
    {
        return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
    }
}

}