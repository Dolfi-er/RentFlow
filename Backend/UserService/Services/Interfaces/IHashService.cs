namespace Backend.Services;

public interface IHashService
{
    string Hash(string text);
    bool Verify(string HashText, string inputText);
}