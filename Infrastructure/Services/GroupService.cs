using System.Net;
using Domain.DTOs.GroupDTO;
using Domain.Responses;
using Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext context) : IGroupService
{
public async Task<Response<List<GetGroupsDTO>>> GetGroups()
{
    try
    {
        var groups = await context.Groups.Where(x => x.Id > 0).ToListAsync();
        var list = new List<GetGroupsDTO>();
        foreach (var g in groups)
        {
            var group = new GetGroupsDTO()
            {
                GroupNick = g.GroupNick,
                ChallengeId = g.ChallengeId,
                NeededMember = g.NeededMember,
                TeamSlogan = g.TeamSlogan,
                CreatedAt = g.CreatedAt,
                Challenge = g.Challenge,
                Participants = g.Participants
            };
            list.Add(group);
        }

        return new Response<List<GetGroupsDTO>>(list);
    }
    catch (Exception e)
    {
        return new Response<List<GetGroupsDTO>>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<GetGroupsDTO>> GetGroupById(int id)
{
    try
    {
        var group = await context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        if (group == null) return new Response<GetGroupsDTO>(HttpStatusCode.BadRequest, "Group not found");
        var response = new GetGroupsDTO()
        {
            GroupNick = group.GroupNick,
            ChallengeId = group.ChallengeId,
            NeededMember = group.NeededMember,
            TeamSlogan = group.TeamSlogan,
            CreatedAt = group.CreatedAt,
            Challenge = group.Challenge,
            Participants = group.Participants
        };
        return new Response<GetGroupsDTO>(response);
    }
    catch (Exception e)
    {
        return new Response<GetGroupsDTO>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<string>> AddGroup(AddGroupDTO group)
{
    try
    {
        var newGroup = new Group()
        {
            GroupNick = group.GroupNick,
            ChallengeId = group.ChallengeId,
            NeededMember = group.NeededMember,
            TeamSlogan = group.TeamSlogan,
            CreatedAt = group.CreatedAt,
            Challenge = group.Challenge,
            Participants = group.Participants
        };
        await context.Groups.AddAsync(newGroup);
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add");
    }
    catch (Exception e)
    {
        return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<string>> UpdateGroup(UpdateGroupDTO group)
{
    try
    {
        var updatedGroup = await context.Groups.FirstOrDefaultAsync(x => x.Id == group.Id);
        if (updatedGroup == null) return new Response<string>("Not found");
        updatedGroup.GroupNick = group.GroupNick;
        updatedGroup.ChallengeId = group.ChallengeId;
        updatedGroup.NeededMember = group.NeededMember;
        updatedGroup.TeamSlogan = group.TeamSlogan;
        updatedGroup.CreatedAt = group.CreatedAt;
        updatedGroup.Challenge = group.Challenge;
        updatedGroup.Participants = group.Participants;
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully updated");
        return new Response<string>("Failed to update");
    }
    catch (Exception e)
    {
        return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<bool>> DeleteGroup(int id)
{
    try
    {
        var existing = await context.Groups.FindAsync(id);
        if (existing == null) return new Response<bool>(HttpStatusCode.BadRequest, "Group not found");
        context.Groups.Remove(existing);
        var res = await context.SaveChangesAsync();
        return new Response<bool>(true);
    }
    catch (Exception e)
    {
        return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
    }
}
}