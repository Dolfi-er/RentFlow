using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Extensions;

public static class RoleExtensions
{
    public static GetRole ToDTO(this Role role)
    {
        return new GetRole()
        {
            Id = role.Id,
            Name = role.Name
        };
    }

    public static Role ToEntity(this PostRole postRole)
    {
        return new Role()
        {
            Id = Guid.NewGuid(),
            Name = postRole.Name
        };
    }
}