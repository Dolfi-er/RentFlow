namespace Backend.DTOs;

public record ChangeTokenDTO
{
    public string AccessToken { get; set; } = string.Empty;
}