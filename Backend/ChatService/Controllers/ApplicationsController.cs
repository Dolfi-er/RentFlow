using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet("{messageId}")]
    public async Task<IActionResult> GetAllByMessageId([FromRoute] Guid messageId)
    {
        var result = await _applicationService.GetByMessageId(messageId);
        return result.ToHttpResult();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] PostApplicationDTO postApplicationDTO)
    {
        var result = await _applicationService.CreateAsync(postApplicationDTO);
        if(!result.IsSuccess) return result.ToHttpResult();
        return StatusCode(201, result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var result =await _applicationService.RemoveAsync(id);
        if(!result.IsSuccess) return result.ToHttpResult();
        return NoContent();
    }
}