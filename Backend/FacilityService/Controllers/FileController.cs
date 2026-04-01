using FacilityService.DTOs;
using FacilityService.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace FacilityService.Controllers;

[ApiController]
[Route("file")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0) return BadRequest("File is empty");

        using Stream stream = file.OpenReadStream();
        ObjectId objectId = await _fileService.Upload(stream, file.FileName);

        return Ok(objectId.ToString());
    }

    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download([FromRoute] string id)
    {
        FileDownloadResult? result = await _fileService.Download(id);
        if (result == null) return NotFound();
        return File(result.Stream, result.ContentType, result.FileName);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Remove([FromRoute] string id)
    {
        bool successfully = await _fileService.Remove(id);
        if (!successfully) return NotFound();
        return Ok();
    }
}