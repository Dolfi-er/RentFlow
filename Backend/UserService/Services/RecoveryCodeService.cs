using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;
using Backend.Share;

namespace Backend.Services;

public class PasswordRecoveryService : IPasswordRecoveryService
{
    private readonly IRecoveryCodeRepository _repository;
    private readonly IEmailService _emailService;
    private readonly IAuthorizationService _authorizationService;

    public PasswordRecoveryService(IRecoveryCodeRepository repository,IEmailService emailService,IAuthorizationService authorizationService)
    {
        _repository = repository;
        _emailService = emailService;
        _authorizationService = authorizationService;
    }

    public async Task<Result<bool>> SendRecoveryCodeAsync(RequestRecoveryDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
            return Result<bool>.Error(ErrorCode.EmptyEmail);

        var code = new Random().Next(100000, 999999).ToString();

        var recoveryData = new RecoveryData
        {
            Code = code,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow,
            IsUsed = false
        };

        var saved = await _repository.SaveRecoveryCodeAsync(
            request.Email, recoveryData, TimeSpan.FromMinutes(15));

        if (!saved)
            return Result<bool>.Error(ErrorCode.RecoveryCodeError);

        await _emailService.SendRecoveryCodeAsync(request.Email, code);

        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> ResetPasswordAsync(ResetPasswordDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) ||string.IsNullOrWhiteSpace(request.Code) || string.IsNullOrWhiteSpace(request.NewPassword))
        {
            return Result<bool>.Error(ErrorCode.EmptyPassword);
        }
        var recoveryData = await _repository.GetRecoveryCodeAsync(request.Email);
        if (recoveryData == null || recoveryData.Code != request.Code) return Result<bool>.Error(ErrorCode.RecoveryCodeError);
        var isValid = !recoveryData.IsUsed && recoveryData.CreatedAt > DateTime.UtcNow.AddMinutes(-15);
        if (!isValid) return Result<bool>.Error(ErrorCode.RecoveryCodeError);
        var changed = await _authorizationService.ChangePassword(request.Email, request.NewPassword);
        if (!changed) return Result<bool>.Error(ErrorCode.SavePasswordError);
        await _repository.DeleteRecoveryCodeAsync(request.Email);
        return Result<bool>.Success(true);
    }
}