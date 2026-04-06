
using Backend.DTOs;
using MongoDB.Bson;

namespace Backend.Repositories;

public interface IFileRepository
{
    Task<FileDownloadResult?> DownloadAsync(string fileId);
    Task<bool> Remove(string fileId);
    Task<ObjectId> UploadAsync(Stream fileStream, string fileName, string? contentType = null);
}
