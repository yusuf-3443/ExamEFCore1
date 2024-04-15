using Domain.Entities;

namespace Domain.DTOs;

public class AddChallengeDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Group>? Groups { get; set; }
}