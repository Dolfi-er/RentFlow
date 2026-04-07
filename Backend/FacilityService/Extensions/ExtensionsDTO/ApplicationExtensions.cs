using FacilityService.DTOs.ApplicationDTOs;
using FacilityService.DTOs.TypeDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class ApplicationExtensions
{
    public static GetApplicationDTO ToDTO(this ApplicationEntity applicationEntity, string baseFileURL)
    {
        return new GetApplicationDTO()
        {
            Id = applicationEntity.Id,
            DocumentId = applicationEntity.DocumentId,
            DocumentRef = baseFileURL + applicationEntity.DocumentId.ToString(),
            ContentType = applicationEntity.ContentType,
            FacilityId = applicationEntity.FacilityId,
        };
    }

    public static ApplicationEntity ToEntity(this PostApplicationDTO postApplicationDTO)
    {
        return new ApplicationEntity()
        {
            DocumentId = postApplicationDTO.DocumentId,
            ContentType = postApplicationDTO.ContentType,
            FacilityId = postApplicationDTO.FacilityId,
        };
    }
}