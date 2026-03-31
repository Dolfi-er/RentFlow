using FacilityService.DTOs.TypeDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
public class TypesController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypesController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _typeService.GetAllAsync());
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] PostTypeDTO postTypeDTO)
    {
        return Ok(await _typeService.CreateAsync(postTypeDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        await _typeService.RemoveAsync(id);
        return Ok();
    }
}