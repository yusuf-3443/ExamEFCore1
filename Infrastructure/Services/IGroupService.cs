using System.Text.RegularExpressions;
using Domain.DTOs.GroupDTO;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IGroupService
{
    Task<Response<List<GetGroupsDTO>>> GetGroups();
    Task<Response<GetGroupsDTO>> GetGroupById(int id);
    Task<Response<string>> AddGroup(AddGroupDTO group);
    Task<Response<string>> UpdateGroup(UpdateGroupDTO group);
    Task<Response<bool>> DeleteGroup(int id);
}