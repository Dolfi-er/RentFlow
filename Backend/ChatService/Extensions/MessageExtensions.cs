using System.Net.Mime;
using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Extensions;

public static class MessageExtensions
{
    public static  Message ToEntity(this PostMessage postMessage, Guid userId)
    {
        return new Message()
        {
            Id =Guid.NewGuid(),
            SenderId =userId,
            StatusId =Guid.Parse("35fbeb05-a68a-4b9e-9cf1-014e711e1ae4"),
            ChatId =postMessage.ChatId,
            Text =postMessage.Text,
            SendDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            DeletedAt =DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc),
            IsDeleted =false
        };
    }
    public static void DeleteMessage(this Message message)
    {
        message.IsDeleted = true;
        message.DeletedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    }
    public static void Update(this Message message, string text)
    {
        message.Text = text ?? message.Text;
    }
    public static GetMessage ToDTO(this Message message, Guid userId)
    {
        return new GetMessage()
        {
            Id =message.Id,
            ChatId =message.ChatId,
            Text =message.Text,
            SenderId =message.SenderId,
            SendDate =message.SendDate,
            IsSender =message.SenderId ==userId
        };
    }
}