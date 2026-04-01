using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Extensions;

public static class UserExtensions
{
    public static GetUser ToDTO(this User user)
    {
        return new GetUser()
        {
            Id = user.Id,
            Login = user.Login,
            Email = user.Email,
            Name = user.UserInfoEntity!.Name,
            Surname = user.UserInfoEntity!.Surname,
            Patronymic = user.UserInfoEntity!.Patronymic,
            PhoneNumber = user.UserInfoEntity!.PhoneNumber,
            Birthday = user.UserInfoEntity!.Birthday,
            Sex = user.UserInfoEntity!.Sex,
            CardNumber = user.UserInfoEntity!.CardNumber
        };
    }

    public static void UpdateUserInfo(this UserInfo userInfo, PutUserInfo putUserInfo)
    {
        userInfo.Name = putUserInfo.Name ?? userInfo.Name;
        userInfo.Surname = putUserInfo.Surname ?? userInfo.Surname;
        userInfo.Patronymic = putUserInfo.Patronymic ?? userInfo.Patronymic;
        userInfo.PhoneNumber = putUserInfo.PhoneNumber ?? userInfo.PhoneNumber;
        userInfo.Birthday = putUserInfo.Birthday ?? userInfo.Birthday;
        userInfo.Sex = putUserInfo.Sex ?? userInfo.Sex;
        userInfo.CardNumber = putUserInfo.CardNumber ?? userInfo.CardNumber;
    }
}