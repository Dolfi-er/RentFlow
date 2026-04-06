using System.Security.Cryptography.X509Certificates;
using Backend.DTOs;
using Backend.Extensions;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Backend.Services;

public class Chatservice : IChatService
{
    private readonly IChatRepository _repository;
    private readonly ITokenAccessor _tokenAccessor;
    private readonly string _baseFileURL;
    public Chatservice(IChatRepository repository, ITokenAccessor tokenAccessor, IConfiguration configuration)
    {
        _repository = repository;
        _tokenAccessor = tokenAccessor;
         _baseFileURL = configuration["FileEndpointBase"]!;
    }
    public async Task<Result<Guid>> CreateChat(PostChat postChat)
    {
        Chat chat = postChat.ToEntity();
        List<ChatUser> chatUsers = ChatExtensions.ToUserChat(chat.Id, new List<Guid> { postChat.User1Id, postChat.User2Id });
        Guid id = await _repository.CreateChat(chat, chatUsers);
        return Result<Guid>.Success(id);
    }

    public async Task<Result<List<GetChat>>> GetAll()
    {
        Guid? userId = _tokenAccessor.GetUserId();
        if(userId is null) return  Result<List<GetChat>>.Error(ErrorCode.InvalidAccessToken);
        List<Chat> chats = await _repository.GetAll(userId.Value);
        List<GetChat> dtos = new List<GetChat>();
        foreach(var chat in chats)
        {
            dtos.Add(chat.ToDTO());
        }
        return Result<List<GetChat>>.Success(dtos);
    }

    public async Task<Result<List<GetChat>>> GetAllByFacilityId(Guid facilityId)
    {
        Guid? userId = _tokenAccessor.GetUserId();
        if(userId is null)  return Result<List<GetChat>>.Error(ErrorCode.InvalidAccessToken);
        List<Chat> chats = await _repository.GetAllByFacilityId(facilityId, userId.Value);
        List<GetChat> dtos = new List<GetChat>();
        foreach(var chat in chats)
        {
            dtos.Add(chat.ToDTO());
        }
        return Result<List<GetChat>>.Success(dtos);
    }

    public async Task<Result<GetExtendedChat>> GetById(Guid chatId)
    {
        Guid? userId = _tokenAccessor.GetUserId();
        if(userId is null)  return Result<GetExtendedChat>.Error(ErrorCode.InvalidAccessToken);
        Chat? chat = await _repository.GetById(userId.Value, chatId);
        if(chat is null ) return Result<GetExtendedChat>.Error(ErrorCode.ChatNotFound);
        return Result<GetExtendedChat>.Success(chat.ToExtendedDTO(userId.Value, _baseFileURL));
    }
}