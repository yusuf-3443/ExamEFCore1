using Domain.Entities;

namespace Domain.DTOs.LocationDTO;

public class UpdateLocationDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Participant>? Participants { get; set; }
}