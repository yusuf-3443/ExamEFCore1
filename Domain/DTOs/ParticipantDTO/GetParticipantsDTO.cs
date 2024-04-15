using Domain.Entities;

namespace Domain.DTOs.ParticipantDTO;

public class GetParticipantsDTO
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public int GroupId { get; set; }
    public int LocationId { get; set; }
    public Group Group { get; set; }
    public Location Location { get; set; }
}