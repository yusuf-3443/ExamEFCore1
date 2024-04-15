namespace Domain.Entities;

public class Group
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