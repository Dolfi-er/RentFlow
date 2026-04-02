namespace Backend.DTOs;

public record RegistrDTO
{
    public Guid RoleId { get; set; }
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string RepeatPassword { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public string PhoneNumber { get; set;} = null!;
    public DateOnly Birthday { get; set; } 
    public string Sex { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
}