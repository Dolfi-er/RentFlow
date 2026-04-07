using FacilityService.DTOs;
using MongoDB.Bson;

namespace FacilityService.Services;

public interface IFileService
{
    Task<FileDownloadResult?> Download(string fileId);
    Task<bool> Remove(string fileId);
    Task<ObjectId> Upload(Stream stream, string fileName);
}
