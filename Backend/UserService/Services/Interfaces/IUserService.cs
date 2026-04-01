using Backend.DTOs;
using Backend.Share;

namespace Backend.Services;

public interface IUserService
{
    Task<Result<GetUser>> GetUser(Guid id);
    Task<Result<bool>> UpdateUserInfo(PutUserInfo putUserInfo);
}