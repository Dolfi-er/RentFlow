using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("auth/password")]
public class PasswordRecoveryController : ControllerBase
{
    private readonly IPasswordRecoveryService _recoveryService;

    public PasswordRecoveryController(IPasswordRecoveryService recoveryService)
    {
        _recoveryService = recoveryService;
    }

    [HttpPost("recovery")]
    public async Task<IActionResult> SendRecoveryCode([FromBody] RequestRecoveryDto request)
    {
        var result = await _recoveryService.SendRecoveryCodeAsync(request);
        return result.ToHttpResult();
    }
    [HttpPost("reset")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
    {
        var result = await _recoveryService.ResetPasswordAsync(request);
        return result.ToHttpResult();
    }
}