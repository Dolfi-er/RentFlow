using Microsoft.AspNetCore.SignalR;
using Backend.Repositories;
using Backend.Share;
using Backend.Services;

namespace Backend.Hubs;

public class ChatHub : Hub
{
    private readonly IChatRepository _chatRepository;
    private readonly ITokenAccessor _tokenAccessor;

    public ChatHub(IChatRepository chatRepository, ITokenAccessor tokenAccessor)
    {
        _chatRepository = chatRepository;
        _tokenAccessor = tokenAccessor;
    }

    public override async Task OnConnectedAsync()
    {
        var userId = _tokenAccessor.GetUserId();
        if (userId is null)
        {
            Context.Abort();
            return;
        }

        var chats = await _chatRepository.GetAll(userId.Value);

        foreach (var chat in chats)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id.ToString());
        }

        await base.OnConnectedAsync();
    }

    public async Task JoinChat(Guid chatId)
    {
        var userId = _tokenAccessor.GetUserId();
        if (userId is null) return;

        var chat = await _chatRepository.GetById(userId.Value, chatId);
        if (chat is null)
            throw new Exception("Нет доступа");

        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    public async Task LeaveChat(Guid chatId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    public async Task Typing(Guid chatId)
    {
        var userId = _tokenAccessor.GetUserId();
        if (userId is null) return;

        await Clients.OthersInGroup(chatId.ToString())
            .SendAsync("UserTyping", userId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }
}