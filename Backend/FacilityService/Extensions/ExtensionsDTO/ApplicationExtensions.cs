using FacilityService.DTOs.ApplicationDTOs;
using FacilityService.DTOs.TypeDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class ApplicationExtensions
{
    public static GetApplicationDTO ToDTO(this ApplicationEntity applicationEntity)
    {
        return new GetApplicationDTO()
        {
            Id = applicationEntity.Id,
            DocumentId = applicationEntity.DocumentId,
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