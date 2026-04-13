using Backend.DTOs;
using Backend.Extensions;
using Backend.Hubs;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;

namespace Backend.Services;

public class MessageService : IMessageService
{
    private readonly ITokenAccessor _tokenAccessor;
    private readonly IMessageRepository _messageRepository;
    private readonly IFileService _fileService;
    private readonly IContentTypeService _contentTypeService;
    private readonly IHubContext<ChatHub> _hub;
    public MessageService(IMessageRepository messageRepository, IFileService fileService, IContentTypeService contentTypeService, ITokenAccessor tokenAccessor, IHubContext<ChatHub> hub)
    {
        _messageRepository = messageRepository;
        _fileService = fileService;
        _contentTypeService = contentTypeService;
        _tokenAccessor = tokenAccessor;
        _hub = hub;
    }

    public async Task<Result<Guid>> CreateMessage(PostMessage postMessage)
    {
        Guid? userId = _tokenAccessor.GetUserId();
        if(userId is null) return Result<Guid>.Error(ErrorCode.InvalidAccessToken);
        Message message = postMessage.ToEntity(userId.Value);
        List<Application> applications =await CreateApplications(message.Id, postMessage.Files);
        Guid id = await _messageRepository.CreateMessage(message, applications);
        var dto =message.ToDTO(userId.Value);
        await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("ReceiveMessage", dto);
        return Result<Guid>.Success(id);
    }

    public async Task<Result<bool>> DeleteMessage(Guid messageId)
    {
        Message? message = await _messageRepository.GetById(messageId);
        if (message is null) return Result<bool>.Error(ErrorCode.MessageNotFound);
        message.DeleteMessage();
        await _messageRepository.UpdateChanges(message);
        await _hub.Clients.Group(message.ChatId.ToString()).SendAsync("MessageDeleted", messageId);
        return Result<bool>.Success(true)!;
    }

    public async Task<Result<bool>> UpdateMessage(PutMessage putMessage)
    {
        Message? message = await _messageRepository.GetById(putMessage.Id);
        if (message is null) return Result<bool>.Error(ErrorCode.MessageNotFound);
        message.Update(putMessage.Text);
        await _messageRepository.UpdateChanges(message);
        await _hub.Clients.Group(message.ChatId.ToString())
            .SendAsync("MessageUpdated", new
            {
                message.Id,
                message.Text
            });
        return Result<bool>.Success(true);
    }

    private async Task<List<Application>> CreateApplications(Guid messageId, List<IFormFile> files)
    {
        List<Application> applicationEntities = new List<Application>();
        foreach (IFormFile file in files)
        {
            using Stream stream = file.OpenReadStream();
            ObjectId documentId = new ObjectId((await _fileService.Upload(stream, file.FileName)).Value);

            Application applicationEntity = new Application()
            {
                Id = Guid.NewGuid(),
                DocumentId = documentId,
                ContentType = _contentTypeService.GetContentType(file.FileName),
                MessageId = messageId
            };

            applicationEntities.Add(applicationEntity);
        }
        return applicationEntities;
    }
}