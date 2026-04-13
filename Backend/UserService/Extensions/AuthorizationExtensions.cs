using Backend.DTOs;
using Backend.Models.Entities;


namespace Backend.Extensions;

public static class AuthorizationExtension
{
    public static User ToEntity(this RegistrDTO dto)
    {
        return new User()
        {
            Id = Guid.NewGuid(),
            RoleId = dto.RoleId,
            Login = dto.Login,
            Email = dto.Email,
            HashPassword = dto.Password
        };
    }
    public static UserInfo ToUserInfo(this RegistrDTO dto, Guid userId)
    {
        return new UserInfo()
        {
            Id = userId,
            Name = dto.Name,
            Surname = dto.Surname,
            Patronymic = dto.Patronymic,
            PhoneNumber = dto.PhoneNumber,
            CardNumber = dto.CardNumber
        };
    }

    public static T With<T>(this T obj, Action<T> setter)
    {
        setter(obj);
        return obj;
    }
}