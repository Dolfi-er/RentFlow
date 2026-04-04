using Backend.DTOs;
using Backend.Share;
using Sprache;

namespace Backend.Services;

public interface IMessageStatusService
{
    Task<Result<List<GetMessageStatus>>> GetALL();
    Task<Result<GetMessageStatus?>> GetById(Guid Id);
    Task<Result<Guid>> CreateMessageStatus(PostMessageStatus postMessageStatus);
}