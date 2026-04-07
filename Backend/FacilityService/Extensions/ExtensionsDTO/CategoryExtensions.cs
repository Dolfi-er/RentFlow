using FacilityService.DTOs.CategoryDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class CategoryExtensions
{
    public static GetCategoryDTO ToDTO(this CategoryEntity categoryEntity)
    {
        return new GetCategoryDTO()
        {
            Id = categoryEntity.Id,
            Name = categoryEntity.Name,
        };
    }

    public static CategoryEntity ToEntity(this PostCategoryDTO postCategoryDTO)
    {
        return new CategoryEntity()
        {
            Name = postCategoryDTO.Name,
        };
    }
}