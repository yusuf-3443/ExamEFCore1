using Domain.Entities;

namespace Domain.DTOs.GroupDTO;

public class GetGroupsDTO
{
    public int Id { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
    public Challenge Challenge { get; set; }
    public List<Participant> Participants { get; set; }
}