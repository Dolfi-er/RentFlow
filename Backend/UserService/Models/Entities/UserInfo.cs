namespace Backend.Models.Entities;

public class UserInfo
{
    public Guid Id { get; set;}
    public required string Name { get; set;}
    public required string Surname { get; set;}
    public required string Patronymic { get; set;}
    public required string PhoneNumber { get; set;}
    public required DateOnly Birthday { get; set;}
    public required string Sex { get; set;}
    public required string CardNumber { get; set;}

    public User? UserEntity { get; set; }
}