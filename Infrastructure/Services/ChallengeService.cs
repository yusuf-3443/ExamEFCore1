using System.Net;
using Domain.DTOs;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ChallengeService(DataContext context) : IChallengeService
{
    public async Task<Response<List<GetChallengesDTO>>> GetChallenges()
    {
        try
        {
            var challenges = await context.Challenges.Where(x => x.Id > 0).ToListAsync();
            var list = new List<GetChallengesDTO>();
            foreach (var c in challenges)
            {
                var challenge = new GetChallengesDTO()
                {
                Title = c.Title,
                Description = c.Description,
                Groups = c.Groups
                };
                list.Add(challenge);
            }
            
            return new Response<List<GetChallengesDTO>>(list);
        }
        catch (Exception e)
        {
            return new Response<List<GetChallengesDTO>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetChallengesDTO>> GetChallengeById(int id)
    {
        try
        {
        var challenge = await context.Challenges.FirstOrDefaultAsync(x => x.Id == id);
        if (challenge == null) return new Response<GetChallengesDTO>(HttpStatusCode.BadRequest, "Challenge not found");
        var response = new GetChallengesDTO()
        {
            Title = challenge.Title,
            Description = challenge.Description,
            Groups = challenge.Groups
        };
        return new Response<GetChallengesDTO>(response);
        }
        catch (Exception e)
        {
            return new Response<GetChallengesDTO>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> AddChallenge(AddChallengeDTO challenge)
    {
        try
        {

        var newChallenge = new Challenge()
        {
        Title = challenge.Title,
        Description = challenge.Description,
        Groups = challenge.Groups
        };
        await context.Challenges.AddAsync(newChallenge);
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateChallenge(UpdateChallengeDTO challenge)
    {
        try
        {

        var updatedchallenge = await context.Challenges.FirstOrDefaultAsync(x => x.Id == challenge.Id);
        if (updatedchallenge == null) return new Response<string>("Not found");
        updatedchallenge.Title = challenge.Title;
        updatedchallenge.Description = challenge.Description;
        updatedchallenge.Groups = challenge.Groups;
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully updated");
        return new Response<string>("Failed to update");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteChallenge(int id)
    {
        try
        {

        var existing = await context.Challenges.FindAsync(id);
        if (existing == null) return new Response<bool>(HttpStatusCode.BadRequest, "Student not found");
        context.Challenges.Remove(existing);
        var res = await context.SaveChangesAsync();
        return new Response<bool>(true);
        
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}