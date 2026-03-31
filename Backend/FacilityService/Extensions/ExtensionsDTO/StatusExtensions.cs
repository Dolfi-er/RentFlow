using FacilityService.DTOs.StatusDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class StatusExtensions
{
    public static GetStatusDTO ToDTO(this StatusEntity statusEntity)
    {
        return new GetStatusDTO()
        {
            Id = statusEntity.Id,
            Name = statusEntity.Name,
        };
    }

    public static StatusEntity ToEntity(this PostStatusDTO postStatusDTO)
    {
        return new StatusEntity()
        {
            Name = postStatusDTO.Name,
        };
    }
}