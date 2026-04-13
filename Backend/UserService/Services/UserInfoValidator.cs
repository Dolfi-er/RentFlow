using System.Data;
using System.Xml;
using Backend.DTOs;
using Backend.Share;
using FluentValidation;

namespace Backend.Services;
public class UserInfoValidator : AbstractValidator<PutUserInfo>
{
    public UserInfoValidator()
    {
        ClassLevelCascadeMode =CascadeMode.Stop;

        RuleFor(dto => dto.Name)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?$").WithErrorCode(ErrorCode.NameError.ToString());

        RuleFor(dto => dto.Surname)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)*$").WithErrorCode(ErrorCode.SurnameError.ToString());

        RuleFor(dto => dto.Patronymic)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?$").WithErrorCode(ErrorCode.PatronymicError.ToString());

        RuleFor(dto => dto.PhoneNumber)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^(\+7|8)\d{10}$").WithErrorCode(ErrorCode.PhoneNumberError.ToString());

        RuleFor(x => x.CardNumber)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^\d{16}$").WithErrorCode(ErrorCode.CardError.ToString());
    }
}