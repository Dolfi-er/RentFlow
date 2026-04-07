using Backend.DTOs;
using Backend.Extensions;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;

namespace Backend.Services;

public class MessageStatusService : IMessageStatusService
{
    private readonly IMessageStatusRepository _messageStatusRepository;
    public MessageStatusService(IMessageStatusRepository messageStatusRepository)
    {
        _messageStatusRepository = messageStatusRepository;
    }

    public async Task<Result<Guid>> CreateMessageStatus(PostMessageStatus postMessageStatus)
    {
        MessageStatus messageStatus = postMessageStatus.ToEntity();
        Guid id = await _messageStatusRepository.CreateNessageStatus(messageStatus);
        return Result<Guid>.Success(id);
    }

    public async Task<Result<List<GetMessageStatus>>> GetALL()
    {
        List<MessageStatus> messageStatuses= await _messageStatusRepository.GetALL();
        List<GetMessageStatus> result= new List<GetMessageStatus>();    
        foreach (var messageStatus in messageStatuses)
        {
            result.Add(messageStatus.ToDTO());
        }
        return Result<List<GetMessageStatus>>.Success(result);
    }

    public async Task<Result<GetMessageStatus?>> GetById(Guid Id)
    {
        MessageStatus? messageStatus = await _messageStatusRepository.GetById(Id);
        if(messageStatus is null) return Result<GetMessageStatus?>.Error(ErrorCode.MessageStatusNotFound);
        return Result<GetMessageStatus?>.Success(messageStatus.ToDTO());
    }
}