using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("auth/")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ITokenAccessor _tokenAccessor;
    public AuthorizationController(IAuthorizationService authorizationService, ITokenAccessor tokenAccessor)
    {
        _authorizationService = authorizationService;
        _tokenAccessor = tokenAccessor;
    }

    [HttpPost("registr")]
    public async Task<IActionResult> Registr([FromBody] RegistrDTO registrDTO)
    {
        Result<Guid?> result = await _authorizationService.RegistrUser(registrDTO);
        return result.ToHttpResult();
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        Result<AnswerLoginDTO> result = await _authorizationService.Login(loginDTO);
        return result.ToHttpResult();
    }
    [HttpPost("logout")]
    [GatewayAuthorize]
    public async Task<IActionResult> Logout()
    {
        Guid? id = _tokenAccessor.GetUserId();
        var result = Result<bool>.CheckToken(id);
        if (!result.IsSuccess) return result.ToHttpResult();
        result = await _authorizationService.Logout(id!.Value);
        return result.ToHttpResult();
    }
    [HttpPost("refresh")]
    [GatewayAuthorize]
    public async Task<IActionResult> Refresh()
    {
        Guid? id = _tokenAccessor.GetUserId();
        var result = Result<bool>.CheckToken(id);
        if (!result.IsSuccess) return result.ToHttpResult();
        var response = await _authorizationService.RefreshToken(id!.Value);
        return response.ToHttpResult();
    }
}