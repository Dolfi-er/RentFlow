using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Share;

public static class ErrorService
{
    public static string GetMessage(ErrorCode? code) => code switch
    {
        ErrorCode.InvalidAccessToken => "ошибка с access токеном",
        _ => "Неизвестная ошибка"
    };
    public static HttpStatusCode GetStatusCode(ErrorCode? code) => code switch
    {
        ErrorCode.InvalidAccessToken => HttpStatusCode.Unauthorized,
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