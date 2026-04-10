using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("role")]

public class RoleController : ControllerBase
{
    private readonly IRoleService _service;
    public RoleController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _service.GetAll();
        return result.ToHttpResult();
    }

    [HttpPost("")]
    [GatewayAuthorize]
    public async Task<IActionResult> CreateRole([FromBody] PostRole postRole)
    {
        var result = await _service.CreateRole(postRole);
        if (!result.IsSuccess) result.ToHttpResult();
        return StatusCode(201, result.Value);
    }
}