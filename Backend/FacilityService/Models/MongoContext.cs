using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace FacilityService.Models;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IMongoClient client)
    {
        _database = client.GetDatabase("FacilityServiceDb");
    }

    public GridFSBucket GridFsBucket => new GridFSBucket(_database);
}