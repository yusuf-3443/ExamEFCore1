using Domain.Entities;

namespace Domain.DTOs;

public class UpdateChallengeDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Group>? Groups { get; set; }
}