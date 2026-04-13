namespace Backend.DTOs;

public record GetUser
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; } 
    public string? PhoneNumber { get; set;} 
    public string? CardNumber { get; set; }

}