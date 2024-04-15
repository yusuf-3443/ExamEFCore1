using Domain.DTOs;
using Domain.DTOs.GroupDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/Groups")]
public class GroupController(IGroupService groupService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetGroupsDTO>>> GetGroups()
    {
        return await groupService.GetGroups();
    }

    [HttpGet("{groupId:int}")]
    public async Task<Response<GetGroupsDTO>> GetGroupById(int groupId)
    {
        return await groupService.GetGroupById(groupId);
    }

    [HttpPost]
    public async Task<Response<string>> AddGroup(AddGroupDTO group)
    {
        return await groupService.AddGroup(group);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGroup(UpdateGroupDTO group)
    {
        return await groupService.UpdateGroup(group);
    }

    [HttpDelete("{groupId:int}")]
    public async Task<Response<bool>> DeleteGroup(int groupId)
    {
        return await groupService.DeleteGroup(groupId);
    }
}
