using Domain.DTOs;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IChallengeService
{
    Task<Response<List<GetChallengesDTO>>> GetChallenges();
    Task<Response<GetChallengesDTO>> GetChallengeById(int id);
    Task<Response<string>> AddChallenge(AddChallengeDTO challenge);
    Task<Response<string>> UpdateChallenge(UpdateChallengeDTO challenge);
    Task<Response<bool>> DeleteChallenge(int id);
}