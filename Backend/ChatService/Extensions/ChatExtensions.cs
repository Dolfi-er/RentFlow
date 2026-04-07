using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Extensions;

public static class ChatExtensions
{
    public static GetChat ToDTO(this Chat chat)
    {
        return new GetChat()
        {
            Id = chat.Id,
            Name = chat.Name
        };
    }

    public static Chat ToEntity(this PostChat postChat)
    {
        return new Chat()
        {
            Id = Guid.NewGuid(),
            Name = postChat.Name,
            FacilityId =postChat.FacilityId
        };
    }

    public static List<ChatUser> ToUserChat(Guid chatId, List<Guid> usersId)
    {
        List<ChatUser> result = new List<ChatUser>();
        for(int i =0; i<usersId.Count(); i++)
        {
            result.Add( new ChatUser()
            {
                Id = Guid.NewGuid(),
                ChatId = chatId,
                UserId =usersId[i]
            });
        }
        return result;
    }
    public static GetExtendedChat ToExtendedDTO(this Chat chat, Guid userId)
    {
        return new GetExtendedChat
        {
            ChatId = chat.Id,
            Messages = chat.MessageEntities.Select(m => new GetChatMessage
            {
                MessageId = m.Id,
                Message = m.Text,
                DateTime = m.SendDate,
                IsSender = m.SenderId == userId,
                Status =m.MessageStatusEntity!.Name
            }).ToList()
        };
    }
}