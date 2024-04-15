using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
namespace WebApi.Controllers;

[ApiController]
[Route("/api/Challenges")]
public class ChallengeController(IChallengeService challengeService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetChallengesDTO>>> GetChallenges()
    {
        return await challengeService.GetChallenges();
    }

    [HttpGet("{challengeId:int}")]
    public async Task<Response<GetChallengesDTO>> GetChallengeById(int challengeId)
    {
        return await challengeService.GetChallengeById(challengeId);
    }

    [HttpPost]
    public async Task<Response<string>> AddChallenge(AddChallengeDTO challenge)
    {
        return await challengeService.AddChallenge(challenge);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateChallenge(UpdateChallengeDTO challenge)
    {
        return await challengeService.UpdateChallenge(challenge);
    }

    [HttpDelete("{challengeId:int}")]
    public async Task<Response<bool>> DeleteChallenge(int challengeId)
    {
        return await challengeService.DeleteChallenge(challengeId);
    }

}