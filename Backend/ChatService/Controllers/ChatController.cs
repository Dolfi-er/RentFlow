using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("dialogue")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateChat([FromBody] PostChat postChat)
    {
        var result = await _chatService.CreateChat(postChat);
        if (!result.IsSuccess) return result.ToHttpResult();
        return StatusCode(201, result.Value);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _chatService.GetAll();
        return result.ToHttpResult();
    }

    [HttpGet("all/{facilityId}")]
    public async Task<IActionResult> GetAllByFacilityId([FromRoute]Guid facilityId)
    {
        var result = await _chatService.GetAllByFacilityId(facilityId);
        return result.ToHttpResult();
    }

    [HttpGet("{chatId}")]
    public async Task<IActionResult> GetById(Guid chatId)
    {
        var result = await _chatService.GetById(chatId);
        return result.ToHttpResult();
    }
}