using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Backend.Models;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IMongoClient client)
    {
        _database = client.GetDatabase("ChatServiceDb");
    }

    public GridFSBucket GridFsBucket => new GridFSBucket(_database);
}