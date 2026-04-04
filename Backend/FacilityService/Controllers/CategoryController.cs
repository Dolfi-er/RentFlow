using FacilityService.DTOs.CategoryDTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacilityService.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] PostCategoryDTO postCategoryDTO)
    {
        return Ok(await _categoryService.CreateAsync(postCategoryDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        await _categoryService.RemoveAsync(id);
        return NoContent();
    }
}