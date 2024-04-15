using Domain.DTOs.ParticipantDTO;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IParticipantService
{
    Task<Response<List<GetParticipantsDTO>>> GetParticipants();
    Task<Response<GetParticipantsDTO>> GetParticipantById(int id);
    Task<Response<string>> AddParticipant(AddParticipantDTO participant);
    Task<Response<string>> UpdateParticipant(UpdateParticipantDTO participant);
    Task<Response<bool>> DeleteParticipant(int id);
}
