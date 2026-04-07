namespace Backend.DTOs;
public record AnswerLoginDTO
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public string CookieName { get; set; } = string.Empty;
    public int ExpireMinutes { get; set; } = 0;
}