using Backend.DTOs;
using Backend.Share;

namespace Backend.Services;

public interface IPasswordRecoveryService
{
    Task<Result<bool>> SendRecoveryCodeAsync(RequestRecoveryDto request);
    Task<Result<bool>> ResetPasswordAsync(ResetPasswordDto request);
}