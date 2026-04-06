namespace Backend.Services;

public class ContentTypeService : IContentTypeService
{
    public string GetContentType(string fileName)
    {
        string extension = Path.GetExtension(fileName)?.ToLowerInvariant()!;
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".svg" => "image/svg+xml",
            ".webp" => "image/webp",
            _ => "application/octet-stream",
        };
    }
}