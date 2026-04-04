using Backend.DTOs;
using Backend.Services;
using Backend.Share;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("messagestatus")]
public class MessageStatusController : ControllerBase
{
    private readonly IMessageStatusService _messageStatusService;
    public MessageStatusController(IMessageStatusService messageStatusService)
    {
        _messageStatusService = messageStatusService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var result =await  _messageStatusService.GetALL();
        return result.ToHttpResult();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _messageStatusService.GetById(id);
        return result.ToHttpResult();
    }
    [HttpPost()]
    public async Task<IActionResult> CreateMessageStatus([FromBody] PostMessageStatus postMessageStatus)
    {
        var result = await _messageStatusService.CreateMessageStatus(postMessageStatus);
        if(!result.IsSuccess) return result.ToHttpResult();
        return CreatedAtAction(nameof(GetById),new { id = result.Value },new { id = result.Value });
    }
}