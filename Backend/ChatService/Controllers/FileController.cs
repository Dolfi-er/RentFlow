
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Backend.Controllers;

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
        if (file == null || file.Length == 0) return Result<ObjectId>.Error(ErrorCode.EmptyFile).ToHttpResult();

        using Stream stream = file.OpenReadStream();
        var result = await _fileService.Upload(stream, file.FileName);
        return result.ToHttpResult();
    }

    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download([FromRoute] string id)
    {
        var result = await _fileService.Download(id);
        if (!result.IsSuccess) return result.ToHttpResult();
        return File(result.Value!.Stream, result.Value!.ContentType, result.Value!.FileName);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Remove([FromRoute] string id)
    {
        var result = await _fileService.Remove(id);
        return result.ToHttpResult();
    }
}