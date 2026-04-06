namespace Backend.DTOs;

public class FileDownloadResult
{
    public Stream Stream { get; set; } = default!;
    public string ContentType { get; set; } = "application/octet-stream";
    public string FileName { get; set; } = string.Empty;
}