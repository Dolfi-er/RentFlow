using Backend.DTOs;
using Backend.Repositories;
using Backend.Share;
using MongoDB.Bson;

namespace Backend.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;
    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<Result<string>> Upload(Stream stream, string fileName)
    {
        return Result<string>.Success((await _fileRepository.UploadAsync(stream, fileName)).ToString());
    }

    public async Task<Result<FileDownloadResult?>> Download(string fileId)
    {
        FileDownloadResult? result =await _fileRepository.DownloadAsync(fileId);
        if(result is null) return Result<FileDownloadResult?>.Error(ErrorCode.FileNotFound);
        return Result<FileDownloadResult?>.Success(result);
    }
    public async Task<Result<bool>> Remove(string fileId)
    {
        bool success = await _fileRepository.Remove(fileId);
        if(!success) return Result<bool>.Error(ErrorCode.FileNotFound);
        return Result<bool>.Success(success);
    }
}