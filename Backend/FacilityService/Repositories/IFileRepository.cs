using FacilityService.DTOs;
using MongoDB.Bson;

namespace FacilityService.Repositories;

public interface IFileRepository
{
    Task<FileDownloadResult?> DownloadAsync(string fileId);
    Task<bool> Remove(string fileId);
    Task<ObjectId> UploadAsync(Stream fileStream, string fileName, string? contentType = null);
}
