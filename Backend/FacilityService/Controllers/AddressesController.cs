using FacilityService.DTOs.AddressDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
[Route("addresses")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly ITokenAccessor _tokenAccessor;

    public AddressesController(IAddressService addressService, ITokenAccessor tokenAccessor)
    {
        _addressService = addressService;
        _tokenAccessor = tokenAccessor;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
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