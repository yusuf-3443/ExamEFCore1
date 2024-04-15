using System.Net;
using Domain.DTOs.ParticipantDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService(DataContext context) : IParticipantService
{
    public async Task<Response<List<GetParticipantsDTO>>> GetParticipants()
{
    try
    {
        var participants = await context.Participants.Where(x => x.Id > 0).ToListAsync();
        var list = new List<GetParticipantsDTO>();
        foreach (var p in participants)
        {
            var participant = new GetParticipantsDTO()
            {
                Fullname = p.Fullname,
                Email = p.Email,
                Phone = p.Phone,
                Password = p.Password,
                CreatedAt = p.CreatedAt,
                GroupId = p.GroupId,
                LocationId = p.LocationId,
                Group = p.Group,
                Location = p.Location
            };
            list.Add(participant);
        }

        return new Response<List<GetParticipantsDTO>>(list);
    }
    catch (Exception e)
    {
        return new Response<List<GetParticipantsDTO>>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<GetParticipantsDTO>> GetParticipantById(int id)
{
    try
    {
        var participant = await context.Participants.FirstOrDefaultAsync(x => x.Id == id);
        if (participant == null) return new Response<GetParticipantsDTO>(HttpStatusCode.BadRequest, "Participant not found");
        var response = new GetParticipantsDTO()
        {
            Fullname = participant.Fullname,
            Email = participant.Email,
            Phone = participant.Phone,
            Password = participant.Password,
            CreatedAt = participant.CreatedAt,
            GroupId = participant.GroupId,
            LocationId = participant.LocationId,
            Group = participant.Group,
            Location = participant.Location
        };
        return new Response<GetParticipantsDTO>(response);
    }
    catch (Exception e)
    {
        return new Response<GetParticipantsDTO>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<string>> AddParticipant(AddParticipantDTO participant)
{
    try
    {
        var newParticipant = new Participant()
        {
            Fullname = participant.Fullname,
            Email = participant.Email,
            Phone = participant.Phone,
            Password = participant.Password,
            CreatedAt = participant.CreatedAt,
            GroupId = participant.GroupId,
            LocationId = participant.LocationId,
            Group = participant.Group,
            Location = participant.Location
        };
        await context.Participants.AddAsync(newParticipant);
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add");
    }
    catch (Exception e)
    {
        return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<string>> UpdateParticipant(UpdateParticipantDTO participant)
{
    try
    {
        var updatedParticipant = await context.Participants.FirstOrDefaultAsync(x => x.Id == participant.Id);
        if (updatedParticipant == null) return new Response<string>("Participant not found");
        updatedParticipant.Fullname = participant.Fullname;
        updatedParticipant.Email = participant.Email;
        updatedParticipant.Phone = participant.Phone;
        updatedParticipant.Password = participant.Password;
        updatedParticipant.CreatedAt = participant.CreatedAt;
        updatedParticipant.GroupId = participant.GroupId;
        updatedParticipant.LocationId = participant.LocationId;
        updatedParticipant.Group = participant.Group;
        updatedParticipant.Location = participant.Location;
        var res = await context.SaveChangesAsync();
        if (res > 0) return new Response<string>("Successfully updated");
        return new Response<string>("Failed to update");
    }
    catch (Exception e)
    {
        return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
    }
}

public async Task<Response<bool>> DeleteParticipant(int id)
{
    try
    {
        var existingParticipant = await context.Participants.FindAsync(id);
        if (existingParticipant == null) return new Response<bool>(HttpStatusCode.BadRequest, "Participant not found");
        
        context.Participants.Remove(existingParticipant);
        var res = await context.SaveChangesAsync();
        
        return new Response<bool>(true);
    }
    catch (Exception e)
    {
        return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
    }
}

}