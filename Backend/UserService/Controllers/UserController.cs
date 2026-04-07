using System.Runtime.CompilerServices;
using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    [GatewayAuthorize]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var result =await _service.GetUser(id);
        return result.ToHttpResult();
    }

    [HttpPut("")]
    [GatewayAuthorize]
    public async Task<IActionResult> UpdateUserInfo([FromBody] PutUserInfo putUserInfo)
    {
        var result = await _service.UpdateUserInfo(putUserInfo);
        return result.ToHttpResult();
    }

}
