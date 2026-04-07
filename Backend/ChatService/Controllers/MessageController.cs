using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("messages")]
public class MessageController  : ControllerBase
{
    private readonly IMessageService _messageService;
    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }
    
    [HttpPost()]
    public async Task<IActionResult> Create([FromForm] PostMessage postMessage)
    {
        var result = await _messageService.CreateMessage(postMessage);
        if(!result.IsSuccess) return result.ToHttpResult();
        return StatusCode(201, result.Value);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result =await _messageService.DeleteMessage(id);
        if(!result.IsSuccess) return result.ToHttpResult();
        return NoContent();
    }
    [HttpPut()]
    public async Task<IActionResult> Put([FromBody] PutMessage putMessage)
    {
        var result = await _messageService.UpdateMessage(putMessage);
        return result.ToHttpResult();
    }
}