using Backend.DTOs;
using Backend.Share;
using MongoDB.Bson;

namespace Backend.Services;

public interface IFileService
{
    Task<Result<FileDownloadResult?>> Download(string fileId);
    Task<Result<bool>> Remove(string fileId);
    Task<Result<string>> Upload(Stream stream, string fileName);
}
