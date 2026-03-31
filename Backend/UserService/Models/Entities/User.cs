namespace Backend.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public required Guid RoleId { get; set; }
    public required string Login { get; set; }
    public required string HashPassword { get; set; }
    public required string Email { get; set; }

    public Role? RoleEntity { get; set; }
    public RefreshToken? RefreshTokenEntity { get; set; }
    public UserInfo? UserInfoEntity { get; set; }
}