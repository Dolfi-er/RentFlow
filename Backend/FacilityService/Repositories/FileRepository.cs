using FacilityService.DTOs;
using FacilityService.Models;
using FacilityService.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace FacilityService.Repositories;

public class FileRepository : IFileRepository
{
    private readonly GridFSBucket _mongoDb;
    private readonly IContentTypeService _contentTypeService;

    public FileRepository(MongoContext mongoDbContext, IContentTypeService contentTypeService)
    {
        _mongoDb = mongoDbContext.GridFsBucket;
        _contentTypeService = contentTypeService;
    }

    public async Task<ObjectId> UploadAsync(Stream fileStream, string fileName, string? contentType = null)
    {
        contentType ??= _contentTypeService.GetContentType(fileName);

        GridFSUploadOptions options = new GridFSUploadOptions()
        {
            Metadata = new BsonDocument
            {
                { "contentType", contentType }
            }
        };

        return await _mongoDb.UploadFromStreamAsync(fileName, fileStream, options);
    }

    public async Task<FileDownloadResult?> DownloadAsync(string fileId)
    {
        ObjectId objectId = ObjectId.Parse(fileId);

        GridFSFileInfo fileInfo = await _mongoDb
            .Find(Builders<GridFSFileInfo>.Filter.Eq(f => f.Id, objectId))
            .FirstOrDefaultAsync();

        if (fileInfo is null) return null;

        var stream = new MemoryStream();
        await _mongoDb.DownloadToStreamAsync(objectId, stream);
        stream.Position = 0;

        string contentType = fileInfo.Metadata?["contentType"]?.AsString 
                            ?? "application/octet-stream";

        string fileName = fileInfo.Filename ?? "file";

        return new FileDownloadResult
        {
            Stream = stream,
            ContentType = contentType,
            FileName = fileName
        };
    }

    public async Task<bool> Remove(string fileId)
    {
        ObjectId objectId = ObjectId.Parse(fileId);

        GridFSFileInfo fileInfo = await _mongoDb.Find(Builders<GridFSFileInfo>.Filter.Eq(f => f.Id, objectId))
                                                .FirstOrDefaultAsync();
        if (fileInfo == null) return false;

        await _mongoDb.DeleteAsync(objectId);
        return true;
    }
}