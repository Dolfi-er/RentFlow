using System.Reflection.Metadata.Ecma335;
using BCrypt;
namespace Backend.Services;

public class HashService : IHashService
{
    public string Hash(string text)
    {
        return BCrypt.Net.BCrypt.HashPassword(text);
    }

    public bool Verify(string HashText, string inputText)
    {
        return BCrypt.Net.BCrypt.Verify(inputText, HashText);
    }
}