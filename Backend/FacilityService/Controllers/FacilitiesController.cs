using FacilityService.DTOs.FacilityDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
[Route("facility")]
public class FacilitiesController : ControllerBase
{
    private readonly IMyFacilityService _facilityService;
    private readonly ITokenAccessor _tokenAccessor;

    public FacilitiesController(IMyFacilityService facilityService, ITokenAccessor tokenAccessor)
    {
        _facilityService = facilityService;
        _tokenAccessor = tokenAccessor;
    }

    
    [HttpGet("getUserId")]
    public async Task<IActionResult> Get()
    {
        return Ok(_tokenAccessor.GetUserId());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        GetFacilityDTO? getFacilityDTO = await _facilityService.GetByIdAsync(id);
        if (getFacilityDTO is null) return NotFound();
        return Ok(getFacilityDTO);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _facilityService.GetAllAsync());
    }

    [HttpGet("owner")]
    public async Task<IActionResult> GetByOwnerAsync()
    {
        Guid? ownerId = _tokenAccessor.GetUserId();
        if (ownerId is null) return Unauthorized();

        return Ok(await _facilityService.GetByOwnerAsync(ownerId.Value));
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromForm] PostFacilityDTO postFacilityDTO)
    {
        Guid? ownerId = _tokenAccessor.GetUserId();
        if (ownerId is null) return Unauthorized();
        return Ok(await _facilityService.CreateAsync(postFacilityDTO, ownerId.Value));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromForm] PutFacilityDTO putFacilityDTO)
    {
        Guid? ownerId = _tokenAccessor.GetUserId();
        if (ownerId is null) return Unauthorized();

        bool isSuccessful = await _facilityService.UpdateAsync(id, ownerId.Value, putFacilityDTO);
        if (isSuccessful) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        await _facilityService.RemoveAsync(id);
        return NoContent();
    }
}