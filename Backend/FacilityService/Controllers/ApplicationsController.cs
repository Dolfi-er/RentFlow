using FacilityService.DTOs.ApplicationDTOs;
using FacilityService.DTOs.TypeDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _applicationService.GetAllAsync());
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] PostApplicationDTO postApplicationDTO)
    {
        return Ok(await _applicationService.CreateAsync(postApplicationDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        await _applicationService.RemoveAsync(id);
        return NoContent();
    }
}