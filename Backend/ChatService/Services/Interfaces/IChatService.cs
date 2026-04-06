using Backend.DTOs;
using Backend.Share;

namespace Backend.Services;

public interface IChatService
{
    Task<Result<List<GetChat>>> GetAll();
    Task<Result<List<GetChat>>> GetAllByFacilityId(Guid facilityId);
    Task<Result<GetExtendedChat>> GetById(Guid chatId);
    Task<Result<Guid>> CreateChat(PostChat postChat);
}