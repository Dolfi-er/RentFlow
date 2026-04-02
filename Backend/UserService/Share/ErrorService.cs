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
        ErrorCode.RecoveryCodeError => "Неверный или просроченный код восстановления",
        ErrorCode.SavePasswordError => "Не удалось сохранить новый пароль",
        ErrorCode.CookieError => "Ошибка с cookie",
        ErrorCode.WrongPassword => "Неверный пароль",
        ErrorCode.NotFoundToken => "Токен не найден",
        ErrorCode.DeleteTokenError => "Не удалось удалить токен",
        ErrorCode.InvalidRefreshToken => "Неверный refresh токен",
        ErrorCode.UserCreationError => "Не удалось создать пользователя",
        ErrorCode.RepeatLogin => "Пользователь с таким логином уже существует",

        _ => "Неизвестная ошибка"
    };

    public static HttpStatusCode GetStatusCode(ErrorCode? code) => code switch
    {
        ErrorCode.InvalidAccessToken => HttpStatusCode.Unauthorized,
        ErrorCode.UserInfoNotFound or ErrorCode.UserNotFound => HttpStatusCode.NotFound,
        ErrorCode.LoginError or ErrorCode.EmailError or ErrorCode.PasswordError or ErrorCode.PasswordMatch or
        ErrorCode.EmptyEmail or ErrorCode.EmptyPassword or ErrorCode.EmptyLogin => HttpStatusCode.BadRequest,
        ErrorCode.NameError or ErrorCode.SurnameError or ErrorCode.PatronymicError or ErrorCode.PhoneNumberError or
        ErrorCode.DateError or ErrorCode.SexError or ErrorCode.CardError => HttpStatusCode.UnprocessableEntity, // 422
        ErrorCode.EmptySex or ErrorCode.EmptyCard or ErrorCode.EmptyName or ErrorCode.EmptySurname or
        ErrorCode.EmptyPatronymic or ErrorCode.EmptyPhoneNumber => HttpStatusCode.BadRequest,
        ErrorCode.RecoveryCodeError or ErrorCode.SavePasswordError => HttpStatusCode.BadRequest,
        ErrorCode.CookieError or ErrorCode.WrongPassword or ErrorCode.InvalidRefreshToken => HttpStatusCode.Unauthorized,
        ErrorCode.NotFoundToken or ErrorCode.DeleteTokenError => HttpStatusCode.NotFound,
        ErrorCode.UserCreationError or ErrorCode.RepeatLogin => HttpStatusCode.Conflict,
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