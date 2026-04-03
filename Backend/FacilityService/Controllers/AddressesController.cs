using FacilityService.DTOs.AddressDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
[Route("addresses")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] Guid id)
    {
        GetAddressDTO? getAddressDTO = await _addressService.GetByIdAsync(id);
        if (getAddressDTO is null) return NotFound();
        return Ok(getAddressDTO);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _addressService.GetAllAsync());
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] PostAddressDTO postAddressDTO)
    {
        return Ok(await _addressService.CreateAsync(postAddressDTO));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] PutAddressDTO putAddressDTO)
    {
        bool isSuccessful = await _addressService.UpdateAsync(id, putAddressDTO);
        if (isSuccessful) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        await _addressService.RemoveAsync(id);
        return NoContent();
    }
}