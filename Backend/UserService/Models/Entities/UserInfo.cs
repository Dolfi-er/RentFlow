namespace Backend.Models.Entities;

public class UserInfo
{
    public Guid Id { get; set;}
    public string? Name { get; set;}
    public string? Surname { get; set;}
    public string? Patronymic { get; set;}
    public string? PhoneNumber { get; set;}
    public  string? CardNumber { get; set;}

    public User? UserEntity { get; set; }
}