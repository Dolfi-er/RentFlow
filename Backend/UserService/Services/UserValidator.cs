using System.Data;
using System.Xml;
using Backend.DTOs;
using Backend.Share;
using FluentValidation;

namespace Backend.Services;
public class UserValidator : AbstractValidator<RegistrDTO>
{
    public UserValidator()
    {
        ClassLevelCascadeMode =CascadeMode.Stop;

        RuleFor(dto => dto.Login)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyLogin.ToString())
            .Matches(@"^[a-zA-Z0-9](?:[a-zA-Z0-9_-]{1,18}[a-zA-Z0-9])?$").WithErrorCode(ErrorCode.LoginError.ToString());

        RuleFor(dto => dto.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyEmail.ToString())
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithErrorCode(ErrorCode.EmailError.ToString());

        RuleFor(dto => dto.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyPassword.ToString())
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,32}$").WithErrorCode(ErrorCode.PasswordError.ToString());

        RuleFor(dto => dto)
            .Cascade(CascadeMode.Stop)
            .Must(dto => dto.Password == dto.RepeatPassword).WithErrorCode(ErrorCode.PasswordMatch.ToString());

        RuleFor(dto => dto.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyName.ToString())
            .Matches(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?$").WithErrorCode(ErrorCode.NameError.ToString());

        RuleFor(dto => dto.Surname)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptySurname.ToString())
            .Matches(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)*$").WithErrorCode(ErrorCode.SurnameError.ToString());

        RuleFor(dto => dto.Patronymic)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyPatronymic.ToString())
            .Matches(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?$").WithErrorCode(ErrorCode.PatronymicError.ToString());

        RuleFor(dto => dto.PhoneNumber)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyPhoneNumber.ToString())
            .Matches(@"^(\+7|8)\d{10}$").WithErrorCode(ErrorCode.PhoneNumberError.ToString());

         RuleFor(dto => dto.Birthday)
            .Cascade(CascadeMode.Stop)
            .InclusiveBetween(new DateOnly(1900, 1, 1), DateOnly.FromDateTime(DateTime.Today))
            .WithErrorCode(ErrorCode.DateError.ToString());

        RuleFor(dto => dto.Sex)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptySex.ToString())
            .Must(s => s == "М" || s == "Ж").WithErrorCode(ErrorCode.SexError.ToString());

        RuleFor(x => x.CardNumber)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode(ErrorCode.EmptyCard.ToString())
            .Matches(@"^\d{16}$").WithErrorCode(ErrorCode.CardError.ToString());
    }
}