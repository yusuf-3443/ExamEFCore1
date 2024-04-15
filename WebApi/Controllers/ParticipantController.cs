using Domain.DTOs.ParticipantDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/Participants")]
public class ParticipantController(IParticipantService participantService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetParticipantsDTO>>> GetParticipants()
    {
        return await participantService.GetParticipants();
    }

    [HttpGet("{participantId:int}")]
    public async Task<Response<GetParticipantsDTO>> GetParticipantById(int participantId)
    {
        return await participantService.GetParticipantById(participantId);
    }

    [HttpPost]
    public async Task<Response<string>> AddParticipant(AddParticipantDTO participant)
    {
        return await participantService.AddParticipant(participant);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateParticipant(UpdateParticipantDTO participant)
    {
        return await participantService.UpdateParticipant(participant);
    }

    [HttpDelete("{participantId:int}")]
    public async Task<Response<bool>> DeleteParticipant(int participantId)
    {
        return await participantService.DeleteParticipant(participantId);
    }
}
