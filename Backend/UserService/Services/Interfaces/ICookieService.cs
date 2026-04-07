namespace Backend.Services;

public interface ICookieService
{
    bool SetCookie(string name, string token, int days);
    string? GetCookie(string key);
    void DeleteCookie(string key);
}