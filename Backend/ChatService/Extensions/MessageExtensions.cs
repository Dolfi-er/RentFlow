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
            StatusId =postMessage.StatusId,
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
}