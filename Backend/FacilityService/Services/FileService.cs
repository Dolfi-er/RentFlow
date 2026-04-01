using FacilityService.DTOs;
using FacilityService.Repositories;
using MongoDB.Bson;

namespace FacilityService.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;
    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<ObjectId> Upload(Stream stream, string fileName)
    {
        return await _fileRepository.UploadAsync(stream, fileName);
    }

    public async Task<FileDownloadResult?> Download(string fileId)
    {
        return await _fileRepository.DownloadAsync(fileId);
    }

    public async Task<bool> Remove(string fileId)
    {
        return await _fileRepository.Remove(fileId);
    }
}