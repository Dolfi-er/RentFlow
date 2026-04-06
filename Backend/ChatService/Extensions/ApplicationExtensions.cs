using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Extensions;

public static class ApplicationExtensions
{
    public static GetApplicationDTO ToDTO(this Application application, string baseFileURL)
    {
        return new GetApplicationDTO()
        {
            Id = application.Id,
            DocumentId = application.DocumentId,
            DocumentRef = baseFileURL + application.DocumentId.ToString(),
            ContentType = application.ContentType,
            MessageId = application.MessageId,
        };
    }

    public static Application ToEntity(this PostApplicationDTO postApplication)
    {
        return new Application()
        {
            Id = Guid.NewGuid(),
            DocumentId = postApplication.DocumentId,
            ContentType = postApplication.ContentType,
            MessageId = postApplication.MessageId
        };
    }
}