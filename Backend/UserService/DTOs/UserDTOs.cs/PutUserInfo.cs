namespace Backend.DTOs;

public record PutUserInfo
{
    public Guid Id { get; set; }
    public string? Name { get; set; } 
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? PhoneNumber { get; set;} 
    public string? CardNumber { get; set;} 
}