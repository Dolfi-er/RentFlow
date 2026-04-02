using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Share;

public static class ErrorService
{
    public static string GetMessage(ErrorCode? code) => code switch
    {
        ErrorCode.InvalidAccessToken => "Ошибка с access токеном",
        ErrorCode.UserInfoNotFound => "Не найдена информация о пользователе",
        ErrorCode.UserNotFound => "Пользователь не найден",
        ErrorCode.LoginError => "Ошибка при логине",
        ErrorCode.EmailError => "Некорректный email",
        ErrorCode.PasswordError => "Некорректный пароль",
        ErrorCode.PasswordMatch => "Пароли не совпадают",
        ErrorCode.NameError => "Некорректное имя",
        ErrorCode.SurnameError => "Некорректная фамилия",
        ErrorCode.PatronymicError => "Некорректное отчество",
        ErrorCode.PhoneNumberError => "Некорректный номер телефона",
        ErrorCode.DateError => "Некорректная дата",
        ErrorCode.EmptySex => "Пол не указан",
        ErrorCode.SexError => "Некорректный пол",
        ErrorCode.EmptyCard => "Номер карты не указан",
        ErrorCode.CardError => "Некорректный номер карты",
        ErrorCode.EmptyLogin => "Логин не указан",
        ErrorCode.EmptyEmail => "Email не указан",
        ErrorCode.EmptyPassword => "Пароль не указан",
        ErrorCode.EmptyName => "Имя не указано",
        ErrorCode.EmptySurname => "Фамилия не указана",
        ErrorCode.EmptyPatronymic => "Отчество не указано",
        ErrorCode.EmptyPhoneNumber => "Телефон не указан",
        _ => "Неизвестная ошибка"
    };

    public static HttpStatusCode GetStatusCode(ErrorCode? code) => code switch
    {
        ErrorCode.InvalidAccessToken => HttpStatusCode.Unauthorized,
        ErrorCode.UserInfoNotFound or ErrorCode.UserNotFound => HttpStatusCode.NotFound,
        ErrorCode.LoginError or ErrorCode.EmailError or ErrorCode.PasswordError or ErrorCode.PasswordMatch => HttpStatusCode.BadRequest,
        ErrorCode.NameError or ErrorCode.SurnameError or ErrorCode.PatronymicError or ErrorCode.PhoneNumberError or ErrorCode.DateError or ErrorCode.SexError or ErrorCode.CardError => HttpStatusCode.UnprocessableEntity, // 422
        ErrorCode.EmptySex or ErrorCode.EmptyCard or ErrorCode.EmptyLogin or ErrorCode.EmptyEmail or ErrorCode.EmptyPassword or ErrorCode.EmptyName or ErrorCode.EmptySurname or ErrorCode.EmptyPatronymic or ErrorCode.EmptyPhoneNumber => HttpStatusCode.BadRequest,
        _ => HttpStatusCode.BadRequest
    };

    public static IActionResult ToHttpResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result);

        var statusCode = GetStatusCode(result.Code);
        var objectResult = new ObjectResult(result)
        {
            StatusCode = (int)statusCode
        };
        return objectResult;
    }
}