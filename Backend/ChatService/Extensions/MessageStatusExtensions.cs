using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Extensions;

public static class MessageStatusExtensions
{
    public static GetMessageStatus ToDTO(this MessageStatus messageStatus)
    {
        return new GetMessageStatus()
        {
            Id = messageStatus.Id,
            Name = messageStatus.Name
        };
    }

    public static MessageStatus ToEntity(this PostMessageStatus postMessageStatus)
    {
        return new MessageStatus()
        {
            Id =Guid.NewGuid(),
            Name =postMessageStatus.Name
        };
    }
}