using FacilityService.DTOs.StatusDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
[Route("statuses")]
public class StatusesController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusesController(IStatusService statusService)
    {
        _statusService = statusService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _statusService.GetAllAsync());
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] PostStatusDTO postStatusDTO)
    {
        return Ok(await _statusService.CreateAsync(postStatusDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        await _statusService.RemoveAsync(id);
        return NoContent();
    }
}