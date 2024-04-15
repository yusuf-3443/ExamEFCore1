using Domain.DTOs.LocationDTO;
using Domain.Responses;

namespace Infrastructure.Services;
public interface ILocationService
{
    Task<Response<List<GetLocationsDTO>>> GetLocations();
    Task<Response<GetLocationsDTO>> GetLocationById(int id);
    Task<Response<string>> AddLocation(AddLocationDTO location);
    Task<Response<string>> UpdateLocation(UpdateLocationDTO location);
    Task<Response<bool>> DeleteLocation(int id);
}
