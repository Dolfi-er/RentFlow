using Backend.DTOs;
using Backend.Share;

namespace Backend.Services;

public interface IMessageService
{
    Task<Result<Guid>> CreateMessage(PostMessage postMessage);
    Task<Result<bool>> DeleteMessage(Guid messageId);
    Task<Result<bool>> UpdateMessage(PutMessage putMessage);
}