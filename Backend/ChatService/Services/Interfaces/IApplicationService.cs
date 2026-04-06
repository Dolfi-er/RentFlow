using Backend.DTOs;
using Backend.Share;

namespace Backend.Services;

public interface IApplicationService
{
    Task<Result<Guid>> CreateAsync(PostApplicationDTO postApplicationDTO);
    Task<Result<List<GetApplicationDTO>>> GetByMessageId(Guid messageId);
    Task<Result<bool>> RemoveAsync(Guid id);
}
